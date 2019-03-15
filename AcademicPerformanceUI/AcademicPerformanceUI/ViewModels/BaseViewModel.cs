﻿using DataAccess;
using DataAccess.Models;
using Services.Serialization;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace AcademicPerformanceUI.ViewModels
{
    public abstract class BaseViewModel<Entity>:INotifyPropertyChanged where Entity: IEntity
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (Equals(storage, value)) return false;

            storage = value;
            this.OnPropertyChanged(propertyName);
            return true;
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public ObservableCollection<Entity> _Entities;
        public Entity _SelectedEntity;

        public virtual Entity SelectedEntity
        {
            get => _SelectedEntity;
            set => SetProperty(ref _SelectedEntity, value);
        }

        public virtual ObservableCollection<Entity> Entities
        {
            get => _Entities;
            set => SetProperty(ref _Entities, value);
        }

        public virtual void AddData()
        {
            var newEntity = (Entity)_SelectedEntity.Clone();
            newEntity.Id = Guid.NewGuid();
            Entities.Add(newEntity);
            InMemory.AddData(newEntity);
            var x  = (IEntity)newEntity;
            Console.WriteLine(x.GetType());
            _SelectedEntity = (Entity)InMemory.CreateNew(typeof(Entity));
        }

        public virtual void RemoveData()
        {
            InMemory.RemoveData(_SelectedEntity);
            Entities.Remove(_SelectedEntity);

            _SelectedEntity = (Entity)InMemory.CreateNew(typeof(Entity));
        }

        public virtual void UpdateData()
        {
            InMemory.UpdateData(SelectedEntity);
            _SelectedEntity = (Entity)InMemory.CreateNew(typeof(Entity));
        }
        public abstract void LoadData();

        public virtual void SaveEntity()
        {
            var service = SerializationServiceFactory.GetSerializationService();
            service.SerializeEntity<Entity>(_SelectedEntity, $"{nameof(Entity)}.xml");
        }

        public virtual void SaveAllEntities()
        {
            var service = SerializationServiceFactory.GetSerializationService();
            service.SerializeEntity<List<Entity>>(_SelectedEntity, $"{nameof(Entity)}.xml");
        }
    }
}
