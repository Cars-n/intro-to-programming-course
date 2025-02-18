import { signal } from '@angular/core';

export class BankService {
  private _currentBalance = signal(5000);

  public getCurrentBalance() {
    return this._currentBalance.asReadonly();
  }

  public deposit(amount: number) {
    this._currentBalance.update((c) => c + amount);
  }

  public withdraw(amount: number) {
    this._currentBalance.update((c) => c - amount);
  }
}
