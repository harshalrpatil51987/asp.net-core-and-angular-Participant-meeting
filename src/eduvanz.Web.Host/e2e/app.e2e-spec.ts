import { eduvanzTemplatePage } from './app.po';

describe('eduvanz App', function() {
  let page: eduvanzTemplatePage;

  beforeEach(() => {
    page = new eduvanzTemplatePage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
   // expect(page.getParagraphText()).toEqual('app works!');
  });
});
