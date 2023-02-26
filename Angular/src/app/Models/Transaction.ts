export interface Transaction{
  id: number;
  date: Date;
  buyCurrencyCode: string;
  sellCurrencyCode: string;
  rate: number;
  amount: number;
}
