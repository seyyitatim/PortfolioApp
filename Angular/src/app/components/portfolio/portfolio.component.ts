import { Component } from '@angular/core';
import { Portfolio } from 'src/app/Models/Portfolio';
import { PortfolioService } from 'src/app/services/portfolio.service';
import { TransactionsService } from 'src/app/services/transactions.service';

@Component({
  selector: 'app-portfolio',
  templateUrl: './portfolio.component.html',
  styleUrls: ['./portfolio.component.css'],
})
export class PortfolioComponent {
  portfolio!: Portfolio[];

  constructor(private portfolioService: PortfolioService, private transactionService: TransactionsService) {}

  ngOnInit() {
    this.transactionService.refresh$.subscribe(this.getPortfolio.bind(this));
    this.getPortfolio();
  }

  getPortfolio() {
    this.portfolioService.getPortfolio().subscribe((response) => {
      this.portfolio = response.portfolios;
      console.log("portfolio çağırıldı");
    });
  }
}
