import { Component } from '@angular/core';
import { Currency } from 'src/app/Models/Currency';
import { CurrencyService } from '../../services/currency.service';

@Component({
  selector: 'app-currency-table',
  templateUrl: './currency-table.component.html',
  styleUrls: ['./currency-table.component.css'],
})
export class CurrencyTableComponent {

  currencies!:Currency[];

  constructor(private currencyService: CurrencyService) {}

  ngOnInit(){
    this.currencyService.getCurrencies()
    .subscribe(response=>{
      this.currencies = response.currencies;
    })
  }
}
