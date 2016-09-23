﻿/* This static class contains some useful methods for creating and configuring game objects.*/

using UnityEngine;
using System.Collections;

namespace CaveGeneration
{
    public static class ObjectFactory
    {
        public static Mesh CreateComponent(Mesh mesh, Transform sector, Material material, string component, Coord index, bool addCollider)
        {
            string name = GetComponentName(component, index);
            mesh.name = name;
            GameObject gameObject = CreateGameObjectFromMesh(mesh, component, sector, material);
            if (addCollider) AddMeshCollider(gameObject, mesh);
            return mesh;
        }

        public static GameObject CreateSector(Coord sectorIndex, Transform parent)
        {
            return CreateChild("Sector " + sectorIndex, parent);
        }

        public static GameObject CreateChild(string name, Transform parent)
        {
            GameObject child = new GameObject(name);
            child.transform.parent = parent;
            return child;
        }

        static string GetComponentName(string component, Coord index)
        {
            return component + " " + index;
        }

        static void AddMeshCollider(GameObject gameObject, Mesh mesh)
        {
            MeshCollider collider = gameObject.AddComponent<MeshCollider>();
            collider.sharedMesh = mesh;
        }

        static GameObject CreateGameObjectFromMesh(Mesh mesh, string name, Transform parent, Material material)
        {
            GameObject newObject = new GameObject(name, typeof(MeshRenderer), typeof(MeshFilter));
            newObject.transform.parent = parent;
            newObject.GetComponent<MeshFilter>().mesh = mesh;
            newObject.GetComponent<MeshRenderer>().material = material;
            newObject.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
            return newObject;
        }
    }
}