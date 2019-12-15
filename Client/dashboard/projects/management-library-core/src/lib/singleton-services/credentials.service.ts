import { Injectable } from '@angular/core';
import { Credentials } from '../models';
export const CURRENT_USER = 'CURRENT_USER';

/**
 * Provides storge for authentication credentials
 * The credentials interface shoule be replaced with proper implementation
 */
@Injectable()
export class CredentialsService {
  // tslint:disable-next-line:variable-name
  private _credentials: Credentials | null = null;

  constructor() {
    const savedCredentials =
      sessionStorage.getItem(CURRENT_USER) ||
      localStorage.getItem(CURRENT_USER);
    if (savedCredentials) {
      this._credentials = JSON.parse(savedCredentials);
    }
  }

  /**
   * Check is the user is authenticated
   */
  get isAuthenticated(): boolean {
    return !!this._credentials;
  }

  get credentials(): Credentials | null {
    return this._credentials;
  }

  setCredentials(credentials?: Credentials, remember?: boolean) {
    this._credentials = credentials || null;
    if (credentials) {
      const storge = remember ? localStorage : sessionStorage;
      storge.setItem(CURRENT_USER, JSON.stringify(credentials));
    } else {
      sessionStorage.removeItem(CURRENT_USER);
      localStorage.removeItem(CURRENT_USER);
      localStorage.clear();
    }
  }
}
