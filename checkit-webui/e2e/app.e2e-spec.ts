import { CheckitWebuiPage } from './app.po';

describe('checkit-webui App', () => {
  let page: CheckitWebuiPage;

  beforeEach(() => {
    page = new CheckitWebuiPage();
  });

  it('should display welcome message', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('Welcome to app!');
  });
});
