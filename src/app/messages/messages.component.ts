import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { MessageService } from '../message.service';
import { Message } from '../message.model';

@Component({
  selector: 'app-messages',
  templateUrl: './messages.component.html',
  styleUrls: ['./messages.component.scss']
})
export class MessagesComponent implements OnInit {
  messages: Message[] = [];
  userId: string = '';
  @ViewChild('messageInput') messageInput: ElementRef | undefined;

  constructor(private messageService: MessageService) { }

  ngOnInit() {
    this.userId = localStorage.getItem('userId') || '';
    this.loadMessages();
  }

  loadMessages() {
    if (this.userId) {
      this.messageService.getMessages(this.userId).subscribe(data => {
        this.messages = data;
      }, error => {
        console.error('Error fetching messages:', error);
      });
    }
  }

  sendMessage(inputElement: HTMLInputElement) {
    const userId = localStorage.getItem('userId');
    const content = inputElement.value;

    if (content && userId) {
      const newMessage: Message = {
        content: content,
        userId: userId,
        date: new Date()
      };

      console.log('Sending message:', newMessage);

      this.messageService.postMessage(newMessage).subscribe(() => {
        console.log('Message sent successfully');
        this.loadMessages();
        inputElement.value = '';
      }, error => {
        console.error('Error posting message:', error);
      });
    } else {
      console.error('Message content and UserId are required');
    }
  }


}
