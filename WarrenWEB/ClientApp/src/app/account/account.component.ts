import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-account',
    templateUrl: './account.component.html'
})
export class AccountComponent {
    public account: Account;
    public transactionValue: number;
    constructor(private http: HttpClient) {
        http.get<Account>(environment.apiUrl + "/12345678").subscribe(result => {
            this.account = result;
    }, error => console.error(error));
    }

    public deposit(value) {
        console.log({ accountNumber: this.account.number, value: +value })
        this.http.post<Account>(environment.apiUrl + "/Deposit", { accountNumber: this.account.number, value: +value }).subscribe(result => {
            this.account = result;
        }, error => console.error(error));
    }

    public withdraw(value) {
        this.http.post<Account>(environment.apiUrl + "/Withdraw", { accountNumber: this.account.number, value: +value }).subscribe(result => {
            this.account = result;
        }, error => console.error(error));
    }

    public payment(value) {
        this.http.post<Account>(environment.apiUrl + "/Payment", { accountNumber: this.account.number, value: +value }).subscribe(result => {
            this.account = result;
        }, error => console.error(error));
    }
}

interface Account {
  number: number;
  value: number;
}
