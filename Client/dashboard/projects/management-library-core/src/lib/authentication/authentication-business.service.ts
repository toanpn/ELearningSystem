import { Credentials } from '../models/credentials';
import { CredentialsService } from '../singleton-services/credentials.service';
import { Injectable } from '@angular/core';

@Injectable()
export class AuthenticationBusinessService {
  constructor(private creadentialsService: CredentialsService) {}

  /**
   * Authentication the user
   * @param context The login paramenters
   * @param remember The user credentials
   */
  login(context: Credentials, remember?: boolean): void {
    this.creadentialsService.setCredentials(context, remember);
  }

  /**
   * Logout and clear credentials
   */
  logout() {
    this.creadentialsService.setCredentials();
  }

  /**
   * Check user is authenticated
   */
  get isAuthenticated(): boolean {
    return !!this.creadentialsService.isAuthenticated;
  }

  /**
   * Get credentials
   */
  get credentials(): Credentials | null {
    return this.creadentialsService.credentials;
  }
}
