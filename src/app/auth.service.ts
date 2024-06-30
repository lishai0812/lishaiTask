import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private apiUrl = 'http://localhost:5018/api/auth/authenticate';

  constructor(private http: HttpClient) { }

  authenticate(userId: string): Observable<any> {
    return this.http.post<any>(this.apiUrl, { UserId: userId });
  }

  logout() {
    localStorage.removeItem('token');
  }
}
