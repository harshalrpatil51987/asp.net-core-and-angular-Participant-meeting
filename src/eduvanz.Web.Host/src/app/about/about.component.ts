import { Component, Injector, ChangeDetectionStrategy, ViewChild, ChangeDetectorRef } from '@angular/core';
import { AppComponentBase } from '@shared/app-component-base';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { MeetupEventsServiceProxy, CreateOrEditMeetupEventDto, StateMaster, MeetupEventDto } from '../../shared/service-proxies/service-proxies';
import { Router, ActivatedRoute } from '@angular/router';
import * as moment from 'moment';
import { Observable } from 'rxjs';
import { finalize } from 'rxjs/operators';
import { NgForm, FormControl, Validators } from '@angular/forms';

@Component({
  templateUrl: './about.component.html',
  animations: [appModuleAnimation()],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class AboutComponent extends AppComponentBase {

    @ViewChild('eventForm') form: NgForm;
    saving = false;
    meetupEvent: CreateOrEditMeetupEventDto = new CreateOrEditMeetupEventDto();
    

    states: StateMaster[];
    guestList: CreateOrEditMeetupEventDto [] = new Array();
   
    public birthdate: Date;
    public age: number=0;
    submitted = false;
    model: any = {};
    eventId: number;
    private sub: any;
    constructor(injector: Injector,
        private _meetupEventsServiceProxy: MeetupEventsServiceProxy,
        private route: ActivatedRoute,
        private ref: ChangeDetectorRef,
        private _router: Router) {
        super(injector);  
        (moment as any).fn.toString = function () { return this.format("L"); };
        this.getStates();
    }
    formControl = new FormControl('', [
        Validators.required,
        Validators.email
    ]);
    show(meetupEventId?: number): void {    
            this._meetupEventsServiceProxy.getMeetupEventForEdit(meetupEventId).subscribe(result => {
                this.guestList = result;
                
                if (this.guestList.length > 0) {
                    this.meetupEvent = this.guestList.find(s => s.parentUser == true);
                    let index = this.guestList.findIndex(s => s.parentUser == true);
                    if (index > -1)
                        this.guestList.splice(index, 1);
                    this.ref.detectChanges()
                }
                else {
                    //this.meetupEvent = new CreateOrEditMeetupEventDto();
                    this.meetupEvent.country = 1;
                    this.meetupEvent.totalGuest = 0;
                    this.meetupEvent.profession = 0;
                    this.ref.detectChanges()
                }
            });
    }
    getStates(): void {
        this._meetupEventsServiceProxy.getstates()
            .subscribe(result => {
                this.states = result;
                this.sub = this.route.params.subscribe(params => {
                    this.eventId = +params['Id'];
                    this.show(this.eventId);
                });
            })
    }
    save() {
        this.submitted = true;
        const controls = this.form.controls;
        if (this.form.invalid) {
            Object.keys(controls).forEach(controlName =>
                controls[controlName].markAsTouched()
            );
            return false;
        }
        
         this._meetupEventsServiceProxy.createOrEdit(this.meetupEvent)
            .pipe(finalize(() => { }))
             .subscribe(result => {
                 this.saveChield();
                 this.saving = false;
                 this._router.navigate(['/app/home']);
                this.notify.info(this.l('SavedSuccessfully'));
             });

        
       
    }
    saveChield() {
        if (!this.guestList)
            this.guestList = [];
        if (this.guestList.length > 0) {
            this._meetupEventsServiceProxy.createOrEditList(this.guestList)
                .pipe(finalize(() => { }))
                .subscribe(result => {
                    this.saving = false;
                    this.notify.info(this.l('SavedSuccessfully'));
                });
        }
    }
    deleteMeetupEvent(i,meetupEvent: CreateOrEditMeetupEventDto): void {
        this.message.confirm(
            'You want to delete :' + meetupEvent.firstName + ' ' + meetupEvent.lastName,
            this.l('AreYouSure'),
            (isConfirmed) => {
                if (isConfirmed) {
                    if (meetupEvent.id) {
                        this._meetupEventsServiceProxy.delete(meetupEvent.id)
                            .subscribe(() => {
                                this.guestList.splice(i, 1);
                                this.meetupEvent.totalGuest = this.guestList.length;
                                this.ref.detectChanges()
                                this.notify.success(this.l('SuccessfullyDeleted'));
                            });
                    }
                    else {
                        this.guestList.splice(i, 1);
                        this.meetupEvent.totalGuest = this.guestList.length;
                        this.ref.detectChanges()
                    }
                }
            }
        );
    }
    deleteClieldMeetupEvent(i, meetupEvent: CreateOrEditMeetupEventDto): void {
        this.message.confirm(
            'You want to delete :' + meetupEvent.firstName + ' ' + meetupEvent.lastName,
            this.l('AreYouSure'),
            (isConfirmed) => {
                if (isConfirmed) {
                    if (meetupEvent.id) {
                        this._meetupEventsServiceProxy.deleteClield(meetupEvent.id)
                            .subscribe(() => {
                                this.guestList.splice(i, 1);
                                this.meetupEvent.totalGuest = this.guestList.length;
                                this.ref.detectChanges()
                                this.notify.success(this.l('SuccessfullyDeleted'));
                            });
                    }
                    else {
                        this.guestList.splice(i, 1);
                        this.meetupEvent.totalGuest = this.guestList.length;
                        this.ref.detectChanges()
                    }
                }
            }
        );
    }

    public CalculateAge(i): void {
        if (i == 99) {
            if (this.meetupEvent.dob) {
                var timeDiff = Math.abs(Date.now() - new Date(moment(this.meetupEvent.dob).toDate()).getTime());
                this.meetupEvent.age = Math.floor(timeDiff / (1000 * 3600 * 24) / 365.25);
                this.ref.detectChanges()
            }
        } else {
            if (this.guestList[i].dob) {
                var timeDiff = Math.abs(Date.now() - new Date(moment(this.guestList[i].dob).toDate()).getTime());
                this.guestList[i].age = Math.floor(timeDiff / (1000 * 3600 * 24) / 365.25);
                this.ref.detectChanges()
            }
        }
    }

    onChange(event) {
     
        if (!this.guestList)
            this.guestList = [];
        let guestcount = this.guestList.length;
        if (event==0)
            this.guestList = [];
        if (event == 1) {
            if (guestcount == 0) {
                let meetupevent = new CreateOrEditMeetupEventDto();
                meetupevent.country = 1;
                meetupevent.init(meetupevent)
                this.guestList.push(meetupevent)              
            }
            if (guestcount == 2) {                
                this.guestList.splice(1,2)
            }
        }
        if (event == 2) {
            if (guestcount == 0) {
                let meetupevent = new CreateOrEditMeetupEventDto();
                meetupevent.init(meetupevent)
                meetupevent.country = 1;
                this.guestList.push(meetupevent)
                this.guestList.push(meetupevent)
            }
            if (guestcount == 1) {
                let meetupevent = new CreateOrEditMeetupEventDto();
                meetupevent.country = 1;
                meetupevent.init(meetupevent)
                this.guestList.push(meetupevent)
            }
        }

        this.ref.detectChanges()
    }
   
}
