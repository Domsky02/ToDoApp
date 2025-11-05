import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class Todo {
  private apiUrl = "http://localhost:5245/api/todo";
  constructor(private http: HttpClient) {
  }

  getTasks() {
    return this.http.get<any[]>(this.apiUrl);
  }

  addTask(newTask: any) {
    return this.http.post(this.apiUrl, newTask)
  }

  updateTaskStatus(id: number, taskToEdit: any) {
    return this.http.put(`${this.apiUrl}/${id}`, taskToEdit)
  }
}
