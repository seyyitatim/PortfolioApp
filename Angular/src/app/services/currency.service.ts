import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Currencies } from '../Models/CurrencyResponse';
import { Observable } from 'rxjs';
import { CurrencyCodeResponse } from '../Models/CurrencyCodeResponse';
import { CurrencyCode } from '../Models/CurrencyCode';
import { BuyCurrency } from '../Models/BuyCurrency';
import { SellCurrency } from '../Models/SellCurrency';

@Injectable({
  providedIn: 'root',
})
export class CurrencyService {
  private baseUrl = 'http://localhost:5023/api/';

  constructor(private httpClient: HttpClient) {}

  getCurrencies(): Observable<Currencies> {
    return this.httpClient.get<Currencies>(
      this.baseUrl + 'common/get-currency'
    );
  }

  getCurrencyCodes(): Observable<CurrencyCodeResponse> {
    return this.httpClient.get<CurrencyCodeResponse>(
      this.baseUrl + 'common/get-currency-code'
    );
  }

  getSalableCurrencyCodes(): Observable<CurrencyCodeResponse> {
    return this.httpClient.get<CurrencyCodeResponse>(
      this.baseUrl + 'portfolio/get-salable-codes'
    );
  }

  buyCurrency(transaction: BuyCurrency): Observable<any> {
    return this.httpClient.post(this.baseUrl+"portfolio/buying-currency",transaction);
  }

  sellCurrency(transaction: SellCurrency): Observable<any> {
    return this.httpClient.post(this.baseUrl+"portfolio/selling-currency",transaction);
  }
}
