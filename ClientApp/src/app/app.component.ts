import { Component, OnInit } from '@angular/core';
import { DataService } from './data.service';
import { Student } from './student';
 
@Component({
    selector: 'app',
    templateUrl: './app.component.html',
    providers: [DataService]
})
export class AppComponent implements OnInit {
 
    student: Student = new Student();   // изменяемый студ
    students: Student[];                // массив студ
    tableMode: boolean = true;          // табличный режим
 
    constructor(private dataService: DataService) { }
 
    ngOnInit() {
        this.loadStudents();    // загрузка данных при старте компонента  
    }
    // получаем данные через сервис
    loadStudents() {
        this.dataService.getStudents()
            .subscribe((data: Student[]) => this.students = data);
    }
    // сохранение данных
    save() {
        if (this.student.id == null) {
            this.dataService.createStudent(this.student)
                .subscribe((data: Student) => this.students.push(data));
        } else {
            this.dataService.updateStudent(this.student)
                .subscribe(data => this.loadStudents());
        }
        this.cancel();
    }
    editStudent(p: Student) {
        this.student = p;
    }
    cancel() {
        this.student = new Student();
        this.tableMode = true;
    }
    delete(p: Student) {
        this.dataService.deleteStudent(p.id)
            .subscribe(data => this.loadStudents());
    }
    add() {
        this.cancel();
        this.tableMode = false;
    }
}