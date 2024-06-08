import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { LoginResponseContract } from '../model/response/LoginResponseContract';
import { shareReplay } from 'rxjs/operators';
import { NewUserContract } from '../model/contract/NewUserContract';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  public Url = 'https://localhost:7255/Auth/';

  constructor(private httpClient: HttpClient) {}

  public login(email: string, password: string) {
    const requestUrl = this.Url + 'login';
    return this.httpClient
      .post<LoginResponseContract>(requestUrl, { email, password })
      .pipe(shareReplay());
  }

  public logout() {
    return this.httpClient.post(this.Url + 'logout', null).pipe(shareReplay());
  }

  public isAuthenticated() {
    return this.httpClient.get(this.Url + 'status').pipe(shareReplay());
  }
  
  public register(newUser: NewUserContract) {
    const requestUrl = this.Url + 'register';
    return this.httpClient.post(requestUrl, newUser).pipe(shareReplay());
  }
}
