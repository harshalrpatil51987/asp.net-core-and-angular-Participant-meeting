import { Component, Injector, ChangeDetectionStrategy, ViewChild, ChangeDetectorRef } from '@angular/core';
import { AppComponentBase } from '@shared/app-component-base';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { MeetupEventsServiceProxy, MeetupEventDto, CreateOrEditMeetupEventDto, StateMaster } from '../../shared/service-proxies/service-proxies';
import { NotifyService } from 'abp-ng2-module';
import { ActivatedRoute, Router } from '@angular/router';
import {
    PagedListingComponentBase,
    PagedRequestDto
} from 'shared/paged-listing-component-base';
import { result } from 'lodash-es';
import { nbLocale } from 'ngx-bootstrap/chronos/i18n/nb';

@Component({
  templateUrl: './home.component.html',
  animations: [appModuleAnimation()],
    changeDetection: ChangeDetectionStrategy.OnPush
})
export class HomeComponent extends AppComponentBase {

    keyword = '';
    isActive: boolean | null;    
    items: MeetupEventDto[];

    
    pager: any = {};
    pagedItems: any[];
    constructor(injector: Injector,
        private _meetupEventsServiceProxy: MeetupEventsServiceProxy,
        private ref: ChangeDetectorRef,
        private _router: Router){
        super(injector);
       
        if (!this.items)
            this.items=[];
        this.getMeetupEvents();
    }
    ngAfterViewInit() {
       
    }
  
    getMeetupEvents() {        
        this._meetupEventsServiceProxy.getAll()
            .subscribe(result => {
                debugger;
                this.items = result;
                this.ref.detectChanges()
            });
    }
    reloadPage(): void {
       
    }
  

    createMeetupEvent(): void {
        this._router.navigate(['/app/about/0']);
    }
    editupEvent(item: MeetupEventDto): void {
        this._router.navigate(['/app/about/' + item.id]);
    }

    deleteMeetupEvent(meetupEvent: MeetupEventDto): void {
        this.message.confirm(
            'You want to delete :'+meetupEvent.firstName+' '+meetupEvent.lastName,
            this.l('AreYouSure'),
            (isConfirmed) => {
                if (isConfirmed) {
                    this._meetupEventsServiceProxy.delete(meetupEvent.id)
                        .subscribe(() => {
                            
                            this.notify.success(this.l('SuccessfullyDeleted'));
                        });
                }
            }
        );
    }
    searchname() { 
        var input, filter, table, tr, td, i, txtValue;
        input = document.getElementById("myInput");
        filter = input.value.toUpperCase();
        table = document.getElementById("myTable");
        tr = table.getElementsByTagName("tr");
        for (i = 0; i < tr.length; i++) {
            td = tr[i].getElementsByTagName("td")[0];
            if (td) {
                txtValue = td.textContent || td.innerText;
                if (txtValue.toUpperCase().indexOf(filter) > -1) {
                    tr[i].style.display = "";
                } else {
                    tr[i].style.display = "none";
                }
            }
        }
    }
}
