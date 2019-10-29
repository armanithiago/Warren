import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Account } from 'src/app/account/account.component';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-account-list',
  templateUrl: './account-list.component.html'
})
export class AccountListComponent {
  public accounts: Account[];

    constructor(http: HttpClient) {
        http.get<Account[]>(environment.apiUrl + '/Accounts').subscribe(result => {
          this.accounts = result;
    }, error => console.error(error));
  }
}
