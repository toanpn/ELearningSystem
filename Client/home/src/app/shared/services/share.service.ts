import {Injectable} from '@angular/core';
import {Subject} from 'rxjs';

@Injectable()
export class ShareService {
  private currentUser = new Subject<any>();

  public currentUserStream$ = this.currentUser.asObservable();

  broadcastCurrentUserChange(user: any) {
    this.currentUser.next(user);
  }
}
