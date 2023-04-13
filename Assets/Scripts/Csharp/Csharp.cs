using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Csharp : MonoBehaviour
{
    // OOP: Object-Oriented Programming ��ü����
    public class ClassExam
    {
        // Member Access Modifier �ɹ� ���� ������
        // ENcapsulationd
        int defVal;
        private int priVal;
        public int pubVal;

        // �Լ�, Function, Method
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


    // ���(Inheritanve)
    // Parent-Child, �θ�-�ڽ� C++
    // Super-Sub,    ����-���� Java
    // Base-Derived, �⺻-�Ļ� C#
    public class Parent
    {
        protected int parentVal;


        // ������(Contructor)
        public Parent()
        {
            Debug.Log("+++++Parent Contructor");
        }
        public Parent(int _i)
        {
            Debug.Log("++++" + _i + "Parent Contructor");
        }

        // �Ҹ���(Destructor)
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

    // �߻�Ŭ������ ��� ������ �ڽ�Ŭ������ �ݵ�� �����Ǹ� �Ͽ����Ѵ�.
    public class APChild : AbstrackParent
    {
        public override void ParentFunc() { }
    }

    // �߻�Ŭ������ �����Ǹ� ������ �� �ִ�
    public abstract class Weapon
    {
        public void Reload() { }
        public abstract void Fire();

    }


    // �����Ǹ� ����
    public interface IWeapon { }
    public interface IWeapon2 { }
    // Interface�� ���� ����� �����ϴ�. ���ǰ� ���⋚��
    public class NewWeapon : IWeapon, IWeapon2 { }


    public class Child : Parent
    {
        private int childVal;


        public Child()
        {
            // C++������ �����ϳ� C#������ �ȵ�
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
        // ���� ������ ������ ���� �Էµ��������� �ڵ����� ���� �Է�
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
        // Polymophism(������)
        Parent parent = new Child();
        parent.ParentFunc();
        //((Child)parent).ChildFunc();
        //Child c = new Parent();
        parent = new NewChild();
        parent.ParentFunc();


        // �߻�Ŭ������ ��ü�� �Ҵ��� �Ұ���
        // AbstrackParent ap = new AbstrackParent();

        Parent p = new Parent(10);

    }
}
