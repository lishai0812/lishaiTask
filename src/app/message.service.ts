import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Message } from './message.model';

@Injectable({
  providedIn: 'root'
})
export class MessageService {
  private apiUrl = 'http://localhost:5018/api/messages';

  constructor(private http: HttpClient) { }

  getMessages(): Observable<Message[]> {
    const token = localStorage.getItem('token');
    console.log('Token sent with getMessages request:', token);
    const headers = new HttpHeaders({
      'Authorization': `Bearer ${localStorage.getItem('token')}`
    });
    return this.http.get<Message[]>(this.apiUrl, { headers });
  }

  postMessage(message: Message): Observable<any> {
    const token = localStorage.getItem('token');
    console.log('Token sent with postMessage request:', token);
    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${localStorage.getItem('token')}`
    });
    return this.http.post<any>(this.apiUrl, message, { headers });
  }
}
