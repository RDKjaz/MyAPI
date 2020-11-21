import { Injectable, InjectionToken } from '@angular/core';
import { HttpClient} from '@angular/common/http';
import { Student } from './student';

@Injectable()
export class DataService {
 
    private url = "/api/students";
 
    constructor(private http: HttpClient) {
    }
 
    getStudents() {
        return this.http.get(this.url);
    }
     
    getStudent(id: number) {
        return this.http.get(this.url + '/' + id);
    }
     
    createStudent(student: Student) {
        return this.http.post(this.url, student);
    }
    updateStudent(student: Student) {
  
        return this.http.put(this.url, student);
    }
    deleteStudent(id: number) {
        return this.http.delete(this.url + '/' + id);
    }
}