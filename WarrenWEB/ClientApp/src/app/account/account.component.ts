import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Router, ActivatedRoute } from '@angular/router';
import { map } from 'rxjs/operators';

@Component({
  selector: 'app-account',
    templateUrl: './account.component.html'
})
export class AccountComponent {
    public account: Account;
    private accountNumber;
    public transactions: Transactions[];
    constructor(private http: HttpClient, private route: ActivatedRoute) {
        route.paramMap.subscribe(params => this.accountNumber = params.get("accountNumber"));
        http.get<Account>(environment.apiUrl + '/' + this.accountNumber).subscribe(result => {
            this.account = result;
        }, error => console.error(error));

        this.updateTransaction();
    }

    public deposit(value) {
        this.http.post<Account>(environment.apiUrl + "/Deposit", { accountNumber: this.account.number, value: +value }).subscribe(result => {
            this.account = result;
            this.updateTransaction();
        }, error => alert(error.error));
    }

    public withdraw(value) {
        this.http.post<Account>(environment.apiUrl + "/Withdraw", { accountNumber: this.account.number, value: +value }).subscribe(result => {
            this.account = result;
            this.updateTransaction();
        }, error => alert(error.error));
    }

    public payment(value) {
        this.http.post<Account>(environment.apiUrl + "/Payment", { accountNumber: this.account.number, value: +value }).subscribe(result => {
            this.account = result;
            this.updateTransaction();
        }, error => alert(error.error));
    }

    private updateTransaction() {
        this.http.get<Transactions[]>(environment.apiUrl + '/Trasaction/' + this.accountNumber).subscribe(result => {
            this.transactions = result;
        }, error => alert(error.error));
    }

    public getTransactionType(transactionType) {
        return transactionType == 0 ? "Depósito" : transactionType == 1 ? "Saque" : "Pagamento";
    }
}

export interface Account {
  number: number;
  value: number;
}

export interface Transactions {
    accountNumber: number,
    transactionType: string,
    transactionValue: number,
    transactionTime : Date
}
