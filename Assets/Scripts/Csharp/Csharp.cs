using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Csharp : MonoBehaviour
{
    // OOP: Object-Oriented Programming 객체지향
    public class ClassExam
    {
        // Member Access Modifier 맴버 접근 지정자
        // ENcapsulationd
        int defVal;
        private int priVal;
        public int pubVal;

        // 함수, Function, Method
        // Getter, Setter
        public void SetPrival(int _prival)
        {
            if (_prival > 10) return;
            priVal = _prival;
        }

        public int GetPriVal()
        {
            if (priVal < 0) return 0;
            return priVal;
        }

        // Properties
        public int Prival
        {
            get { return Prival; }
            set
            {
                if (value > 10) return;
                priVal = value;
            }
        }

        public int val { get; set; }
    }


    // 상속(Inheritanve)
    // Parent-Child, 부모-자식 C++
    // Super-Sub,    슈퍼-서브 Java
    // Base-Derived, 기본-파생 C#
    public class Parent
    {
        protected int parentVal;


        // 생성자(Contructor)
        public Parent()
        {
            Debug.Log("+++++Parent Contructor");
        }
        public Parent(int _i)
        {
            Debug.Log("++++" + _i + "Parent Contructor");
        }

        // 소멸자(Destructor)
        ~Parent()
        {
            Debug.Log("-----Parent Destructor");
        }


        public virtual void ParentFunc()
        {
            Debug.Log("parentVal: " + parentVal);
        }
    }

    // Abstract
    public abstract class AbstrackParent
    {
        // Pure Virtual Class / Function
        public abstract void ParentFunc();
    }

    // 추상클래스를 상속 받으면 자식클리스는 반드시 재정의를 하여야한다.
    public class APChild : AbstrackParent
    {
        public override void ParentFunc() { }
    }

    // 추상클래스는 재정의를 강제할 수 있다
    public abstract class Weapon
    {
        public void Reload() { }
        public abstract void Fire();

    }


    // 재정의를 강제
    public interface IWeapon { }
    public interface IWeapon2 { }
    // Interface는 다중 상속이 가능하다. 정의가 없기떄문
    public class NewWeapon : IWeapon, IWeapon2 { }


    public class Child : Parent
    {
        private int childVal;


        public Child()
        {
            // C++에서는 가능하나 C#에서는 안됨
            // base.Parent();
            Debug.Log("+++++Child Constructor");
        }
        ~Child()
        {
            Debug.Log("-----Child Destructor");
        }


        public void ChildFunc()
        {
            Debug.Log("childVal: " + childVal);
            ParentFunc();
            parentVal = 10;
        }


        // Function Overloading
        public void func() { }
        public void func(int _i) { }
        public void func(int _i, float _f) { }
        public void func(float _f) { }


        // Default Parameter
        // 따로 정해진 형식의 값이 입력되지않으면 자동으로 값을 입력
        public void DefFunc(int _i = 10)
        {
            Debug.Log("_i: " + _i);
        }


        // Function Overriding
        public override void ParentFunc()
        {
            Debug.Log("Child-ParentFunc");
        }
    }


    public class NewChild : Parent
    {
        public override void ParentFunc()
        {
            base.ParentFunc();
            Debug.Log("NewChild ParentFunc");
        }
    }


    private void Start()
    {
        ClassExam ce = new ClassExam();
        ce.SetPrival(10);
        ce.GetPriVal();

        Child child = new Child();
        child.ParentFunc();
        child.DefFunc();


        Debug.Log("===============================================");
        // Polymophism(다형성)
        Parent parent = new Child();
        parent.ParentFunc();
        //((Child)parent).ChildFunc();
        //Child c = new Parent();
        parent = new NewChild();
        parent.ParentFunc();


        // 추상클래스는 객체로 할당이 불가능
        // AbstrackParent ap = new AbstrackParent();

        Parent p = new Parent(10);

    }
}
