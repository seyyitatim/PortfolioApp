import { Component } from '@angular/core';
import { Transaction } from 'src/app/Models/Transaction';
import { TransactionsService } from 'src/app/services/transactions.service';

@Component({
  selector: 'app-transactions',
  templateUrl: './transactions.component.html',
  styleUrls: ['./transactions.component.css'],
})
export class TransactionsComponent {
  transactions!: Transaction[];

  constructor(private transactionService: TransactionsService) {}

  ngOnInit() {
    this.transactionService.refresh$.subscribe(this.getTransaction.bind(this));
    this.getTransaction();
  }

  getTransaction() {
    this.transactionService.getTransactions().subscribe((response) => {
      this.transactions = response.transactions;
      console.log("transaction çağırıldı");
    });
  }
}
