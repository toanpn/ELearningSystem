import {Injectable} from '@angular/core';
import {Subject} from 'rxjs';

@Injectable()
export class ShareService {
  private currentUser = new Subject<any>();
  private myTitle = new Subject<string>();

  public currentUserStream$ = this.currentUser.asObservable();
  public myTitleStream$ = this.myTitle.asObservable();

  broadcastCurrentUserChange(user: any) {
    this.currentUser.next(user);
  }

  broadcastTitle(title: string) {
    this.myTitle.next(title);
  }
}
