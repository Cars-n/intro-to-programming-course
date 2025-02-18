import { Routes } from '@angular/router';
import { BankingComponent } from './banking.component';
import { DepositComponent } from './components/deposit.component';
import { WithdrawComponent } from './components/withdraw.component';
import { BankService } from './services/bank.service';
import { BankStore } from './services/bank.store';
export const BANKING_ROUTES: Routes = [
  {
    path: '',
    component: BankingComponent,
    providers: [BankStore], // will keep in memory until page refresh as opposed to putting in component
    children: [
      {
        path: 'withdrawal', // banking/withdrawal
        component: WithdrawComponent,
      },
      {
        path: 'deposit',
        component: DepositComponent,
      },
    ],
  },
];
