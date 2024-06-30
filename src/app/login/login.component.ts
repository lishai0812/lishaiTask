// import { Component } from '@angular/core';
// import { Router } from '@angular/router';
// import { MessageService } from '../message.service';

// @Component({
//   selector: 'app-login',
//   templateUrl: './login.component.html',
//   styleUrls: ['./login.component.scss']
// })
// export class LoginComponent {
//   userId: string = '';

//   constructor(private messageService: MessageService, private router: Router) { }

//   submitId(userIdInput : string) {
//     if(userIdInput){
//     this.messageService.authenticateUser(userIdInput).subscribe(response => {
//       if (response.authenticated) {
//         localStorage.setItem('userId', userIdInput);
//         this.router.navigate(['/messages']);
//       } else {
//         alert('Invalid ID');
//       }
//     });
//   }
//   }
// }


// login.component.ts
import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent {
  userId: string = '';

  constructor(private authService: AuthService, private router: Router) { }


  login(userIdInput : string) {
       if(userIdInput){
    this.authService.authenticate(userIdInput).subscribe(response => {
      if (response.token) {
        localStorage.setItem('token', response.token);
        console.log('Token in localStorage:', localStorage.getItem('token'));
        this.router.navigate(['/messages']);
      } else {
        alert('Invalid ID');
      }
    });
  }}
}
