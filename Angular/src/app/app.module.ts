import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClientModule } from '@angular/common/http';
import { ToastrModule } from 'ngx-toastr';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CurrencyTableComponent } from './components/currency-table/currency-table.component';
import { PortfolioComponent } from './components/portfolio/portfolio.component';
import { TransactionsComponent } from './components/transactions/transactions.component';
import { PanelComponent } from './components/panel/panel.component';
import { FormsModule } from '@angular/forms';

@NgModule({
  declarations: [AppComponent, CurrencyTableComponent, PortfolioComponent, TransactionsComponent, PanelComponent],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    HttpClientModule,
    FormsModule,
    ToastrModule.forRoot({
      positionClass: 'toast-bottom-right'
    })
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
