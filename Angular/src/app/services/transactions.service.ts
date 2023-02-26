import { HttpClient } from '@angular/common/http';
import { EventEmitter, Injectable } from '@angular/core';
import { TransactionResponse } from '../Models/TransactionResponse';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class TransactionsService {
  private url = 'http://localhost:5023/api/Transaction';

  public refresh$ = new EventEmitter();

  constructor(private httpClient: HttpClient) {}

  getTransactions(): Observable<TransactionResponse> {
    return this.httpClient.get<TransactionResponse>(this.url);
  }
  refresh(): void {
    this.refresh$.emit("abc");
  }
}
