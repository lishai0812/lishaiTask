// message.model.ts
export interface Message {
  content: string;
  date?: Date;
  userId: string;
}

// user.model.ts
export interface User {
  userId: string;
}
