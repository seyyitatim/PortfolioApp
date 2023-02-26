import { Component } from '@angular/core';
import { BuyCurrency } from 'src/app/Models/BuyCurrency';
import { NgForm } from '@angular/forms';
import { CurrencyService } from 'src/app/services/currency.service';
import { CurrencyCode } from 'src/app/Models/CurrencyCode';
import { ToastrService } from 'ngx-toastr';
import { TransactionsService } from 'src/app/services/transactions.service';
import { PortfolioService } from 'src/app/services/portfolio.service';

@Component({
  selector: 'app-panel',
  templateUrl: './panel.component.html',
  styleUrls: ['./panel.component.css'],
})
export class PanelComponent {
  buyingAmount: number = 0;
  sellingAmount: number = 0;
  selectedBuyingCurrencyCode: string = '';
  selectedSellingCurrencyCode: string = '';

  currencies!: CurrencyCode[];
  salableCurrencies!: CurrencyCode[];
  constructor(
    private currencyService: CurrencyService,
    private toastr: ToastrService,
    private transactionService: TransactionsService,
    private portolioService: PortfolioService
  ) {}
  ngOnInit(): void {
    this.currencyService.getCurrencyCodes().subscribe((response) => {
      this.currencies = response.currencyCodes;
    });

    this.currencyService.getSalableCurrencyCodes().subscribe((response) => {
      this.salableCurrencies = response.currencyCodes;
    });
  }

  buyCurrency() {
    this.currencyService
      .buyCurrency({
        amount: this.buyingAmount,
        code: this.selectedBuyingCurrencyCode,
      })
      .subscribe({
        error: () => this.toastr.error('İşleminiz gerçekleştirilemedi!'),
        next: () => {
          this.toastr.success('İşleminiz gerçekleştirildi');
          this.transactionService.refresh();
        },
      });
  }

  sellCurrency() {
    this.currencyService
      .sellCurrency({
        amount: this.sellingAmount,
        code: this.selectedSellingCurrencyCode,
      })
      .subscribe({
        error: () => this.toastr.error('İşleminiz gerçekleştirilemedi!'),
        next: () => {
          this.toastr.success('İşleminiz gerçekleştirildi');
          this.transactionService.refresh();
        },
      });
  }

  reset() {
    this.portolioService.reset().subscribe({
      error: () => this.toastr.error('İşleminiz gerçekleştirilemedi!'),
      next: () => {
        this.toastr.success('İşleminiz gerçekleştirildi');
        this.transactionService.refresh();
      },
    });
  }
}
