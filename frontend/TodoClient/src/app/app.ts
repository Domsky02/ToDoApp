import { Component, signal, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Todo } from './todo';


@Component({
  selector: 'app-root',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App implements OnInit{
  protected readonly title = signal('TodoClient');
  public todoList = signal<any[]>([]);
  public newTaskTitle = signal<string>("");

  constructor(private todo: Todo) { }

  ngOnInit() {
    this.todo.getTasks().subscribe(result => {
      this.todoList.set(result);
    });
  }

  addNewTask() {
    const newTask = { tytul: this.newTaskTitle(), opis: '', czyZrobione: false };
    this.todo.addTask(newTask).subscribe(result => {
      this.newTaskTitle.set('');
      this.ngOnInit();
    })
  }

  changeStatus(task: any) {
    task.czyZrobione = !task.czyZrobione;
    this.todo.updateTaskStatus(task.id, task).subscribe();
  }
}
