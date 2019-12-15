import { Injectable } from '@angular/core';
import { Subject, Observable } from 'rxjs';

@Injectable()
export class DashboardSandboxService {
  private titlePage: Subject<string> = new Subject();
  constructor() {}

  getTitle(): Observable<string> {
    return this.titlePage;
  }

  setTitle(title: string) {
    setTimeout(() => this.titlePage.next(title), 200);
  }
}
