import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Basket } from '../shared/models/basket';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class BasketService {
  baseUrl = environment.apiUrl;
  private basketSource = new BehaviorSubject<Basket | null>(null);
  basketSource$ = this.basketSource.asObservable();

  constructor(private http : HttpClient) { }

  getBasket(id: string){
    this.http.get<Basket>(this.baseUrl + '/basket?id=' + id).subscribe({
      next: basket => this.basketSource.next(basket)
    });
  }

  setBasket(basket : Basket) {
    this.http.post<Basket>(this.baseUrl + '/basket', basket).subscribe({
      next : basket => this.basketSource.next(basket)
    });
  }

  getCurrentBasketValue(id: string) {
    return this.basketSource.getValue;
  }
}
