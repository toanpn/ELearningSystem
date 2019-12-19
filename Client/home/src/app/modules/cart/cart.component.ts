import { takeUntil } from 'rxjs/operators';
import { Observable, Subject } from 'rxjs';
import { CartService } from './../../core/services/cart.service';
import { Component, OnInit, OnDestroy } from '@angular/core';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.scss']
})
export class CartComponent implements OnInit, OnDestroy {
  carts$: Observable<any>;
  private destroyed$ = new Subject();
  constructor(private cartService: CartService) {}

  ngOnInit() {
    this.loadCarts();
  }

  ngOnDestroy(): void {
    this.destroyed$.next();
    this.destroyed$.complete();
  }

  loadCarts() {
    this.carts$ = this.cartService
      .loadAllCart()
      .pipe(takeUntil(this.destroyed$));
  }

  onBuyCourse(courseId) {
    this.cartService.buyCourse(courseId).subscribe(res => {
      this.loadCarts();
    });
  }
}
