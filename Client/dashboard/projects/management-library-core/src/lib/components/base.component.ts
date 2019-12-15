import { Injector } from '@angular/core';
import { Title } from '@angular/platform-browser';

export abstract class BaseComponent {
  titlePage: string;
  pageNumber = '0';
  pageSize = '20';
  private titleService: Title;

  public constructor(protected injector: Injector) {
    this.titleService = injector.get(Title);
  }

  protected setTitle(newTitle?: string) {
    this.titleService.setTitle(newTitle || this.titlePage);
  }

  protected getTitle(): string {
    return this.titleService.getTitle();
  }

  protected addClassPage(className: string) {
    if (document.getElementsByTagName('body')) {
      document.getElementsByTagName('body')[0].setAttribute('class', className);
    }
  }

  protected removeClassPage(className?: string) {
    if (document.getElementsByTagName('body')) {
      document.getElementsByTagName('body')[0].removeAttribute('class');
    }
  }
}
