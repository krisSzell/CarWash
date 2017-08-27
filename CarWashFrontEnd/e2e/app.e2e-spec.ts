import { CarWashFrontEndPage } from './app.po';

describe('car-wash-front-end App', () => {
  let page: CarWashFrontEndPage;

  beforeEach(() => {
    page = new CarWashFrontEndPage();
  });

  it('should display welcome message', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('Welcome to app!!');
  });
});
