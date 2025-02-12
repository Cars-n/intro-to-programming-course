import { Routes } from '@angular/router';
import { TodoListComponent } from './pages/todo-list.component';

export const routes: Routes = [
  {
    path: 'todo-list', // URL path for the todo list
    component: TodoListComponent, // Component to display for the todo-list path
  },
];
