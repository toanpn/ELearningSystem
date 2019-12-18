import {Injectable} from '@angular/core';
import {Subject} from 'rxjs';

@Injectable()
export class ShareService {
  private currentUser = new Subject<any>();
  private myTitle = new Subject<string>();
  private numberItemOfCart = new Subject<number>();

  public currentUserStream$ = this.currentUser.asObservable();
  public myTitleStream$ = this.myTitle.asObservable();
  public numberItemOffCartStream$ = this.numberItemOfCart.asObservable();

  broadcastCurrentUserChange(user: any) {
    this.currentUser.next(user);
  }

  broadcastTitle(title: string) {
    this.myTitle.next(title);
  }

  broadcastCartChange(numberOfItem: number) {
    this.numberItemOfCart.next(numberOfItem);
  }
}
