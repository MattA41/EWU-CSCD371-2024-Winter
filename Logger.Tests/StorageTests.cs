using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Logger.Tests;
    public class StorageTests
    {
    [Fact]

    public void AddStudent_StudentAdded()
    {
        Storage storage = new();
        Student student = new(new FullName("First", "Last"));


        storage.Add(student);

        Assert.True(storage.Contains(student));
    }
    [Fact]

    public void AddBook_BookAdded()
    {
        Storage storage = new();
        Book book = new("Book Title");


        storage.Add(book);

        Assert.True(storage.Contains(book));
    }
    [Fact]

    public void AddEmployee_EmployeeAdded()
    {
        Storage storage = new();
        Employee employee = new(new FullName("First", "Last"));


        storage.Add(employee);

        Assert.True(storage.Contains(employee));
    }
    [Fact]
    public void RemoveEmployee_EmployeeRemoved()
    {
        Storage storage = new();
        Employee employee = new(new FullName("First", "Last"));


        storage.Add(employee);

        Assert.True(storage.Contains(employee));
        storage.Remove(employee);
        Assert.False(storage.Contains(employee));
    }
    [Fact]
    public void RemoveStudent_StudentRemoved()
    {
        Storage storage = new();
        Student student = new(new FullName("First", "Last"));


        storage.Add(student);

        Assert.True(storage.Contains(student));
        storage.Remove(student);
        Assert.False(storage.Contains(student));
    }
    [Fact]

    public void RemoveBook_BookRemoved()
    {
        Storage storage = new();
        Book book = new("Book Title");


        storage.Add(book);

        Assert.True(storage.Contains(book));
        storage.Remove(book);

        Assert.False(storage.Contains(book));
    }
}

