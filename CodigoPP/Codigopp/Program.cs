using System;
using System.Collections.Generic;

// Clase que representa una calificación
class Grade
{
    private double score;

    public double GetScore()
    {
        return score;
    }

    public void SetScore(double score)
    {
        this.score = score;
    }

    public string GetLetterGrade()
    {
        if (score >= 90) return "A";
        else if (score >= 80) return "B";
        else if (score >= 70) return "C";
        else if (score >= 60) return "D";
        else return "F";
    }
}

// Clase que representa a un estudiante
class Student
{
    public string Name { get; private set; }
    public int Id { get; private set; }
    public Grade Grade { get; private set; }

    public Student(string name, int id)
    {
        Name = name;
        Id = id;
        Grade = new Grade();
    }

    public void SetGrade(double score)
    {
        Grade.SetScore(score);
    }
}

// Clase para gestionar estudiantes
class StudentManager
{
    private List<Student> students = new List<Student>();

    public void AddStudent(Student student)
    {
        students.Add(student);
    }

    public Student GetStudentById(int id)
    {
        return students.Find(student => student.Id == id);
    }

    public List<Student> GetAllStudents()
    {
        return students;
    }
}

// Uso del sistema
class Program
{
    static void Main()
    {
        StudentManager manager = new StudentManager();

        // Agregar estudiantes
        Student student1 = new Student("Juan Pérez", 1);
        Student student2 = new Student("María López", 2);

        manager.AddStudent(student1);
        manager.AddStudent(student2);

        // Asignar calificaciones
        student1.SetGrade(85);
        student2.SetGrade(92);

        // Mostrar información del estudiante
        foreach (var student in manager.GetAllStudents())
        {
            Console.WriteLine($"Nombre: {student.Name}");
            Console.WriteLine($"ID: {student.Id}");
            Console.WriteLine($"Calificación: {student.Grade.GetScore()}");
            Console.WriteLine($"Letra: {student.Grade.GetLetterGrade()}");
            Console.WriteLine();
        }
    }
}

