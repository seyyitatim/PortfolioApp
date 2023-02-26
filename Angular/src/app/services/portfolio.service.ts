import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { PortfolioResponse } from '../Models/PortfolioResponse';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class PortfolioService {
  private url = 'http://localhost:5023/api/';
  constructor(private httpClient: HttpClient) {}

  getPortfolio(): Observable<PortfolioResponse> {
    return this.httpClient.get<PortfolioResponse>(
      this.url + 'Portfolio/get-portfolios'
    );
  }

  reset(): Observable<any> {
    return this.httpClient.delete(this.url + 'Portfolio/reset');
  }
}
