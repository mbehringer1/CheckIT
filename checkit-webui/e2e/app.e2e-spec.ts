import { CheckitWebuiPage } from './app.po';

describe('checkit-webui App', function() {
  let page: CheckitWebuiPage;

  beforeEach(() => {
    page = new CheckitWebuiPage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
