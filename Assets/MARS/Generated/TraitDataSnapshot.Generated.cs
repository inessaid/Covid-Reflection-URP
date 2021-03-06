// This file is automatically generated - DO NOT EDIT MANUALLY!
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MARS.Authoring;
using Unity.MARS.Query;
using Unity.XRTools.ModuleLoader;

namespace Unity.MARS.Data
{
    public partial class TraitDataSnapshot
    {
        readonly Dictionary<string, System.Boolean> m_SemanticTagTraits = Pools.SemanticTagResults.Get();

        readonly Dictionary<string, System.Int32> m_IntTraits = Pools.IntResults.Get();

        readonly Dictionary<string, System.Single> m_FloatTraits = Pools.FloatResults.Get();

        readonly Dictionary<string, System.String> m_StringTraits = Pools.StringResults.Get();

        readonly Dictionary<string, UnityEngine.Pose> m_PoseTraits = Pools.PoseResults.Get();

        readonly Dictionary<string, UnityEngine.Vector2> m_Vector2Traits = Pools.Vector2Results.Get();

        void Clear()
        {
            m_SemanticTagTraits.Clear();

            m_IntTraits.Clear();

            m_FloatTraits.Clear();

            m_StringTraits.Clear();

            m_PoseTraits.Clear();

            m_Vector2Traits.Clear();
        }

        /// <summary>
        /// Save a snapshot that contains all the data currently associated with a query result
        /// </summary>
        /// <param name="queryResult">The query result to get the data from.</param>
        public void TakeSnapshot(QueryResult queryResult)
        {
            Clear();
            DataID = -1;

            var db = ModuleLoaderCore.instance.GetModule<MARSDatabase>();
            if (db == null || queryResult == null)
                return;

            DataID = queryResult.DataID;

            db.GetTraitProvider(out MARSTraitDataProvider<System.Boolean> semanticTagProvider);
            MARSDatabase.GetAllTraitsForId(queryResult.DataID, semanticTagProvider, m_SemanticTagTraits);

            db.GetTraitProvider(out MARSTraitDataProvider<System.Int32> intProvider);
            MARSDatabase.GetAllTraitsForId(queryResult.DataID, intProvider, m_IntTraits);

            db.GetTraitProvider(out MARSTraitDataProvider<System.Single> floatProvider);
            MARSDatabase.GetAllTraitsForId(queryResult.DataID, floatProvider, m_FloatTraits);

            db.GetTraitProvider(out MARSTraitDataProvider<System.String> stringProvider);
            MARSDatabase.GetAllTraitsForId(queryResult.DataID, stringProvider, m_StringTraits);

            db.GetTraitProvider(out MARSTraitDataProvider<UnityEngine.Pose> poseProvider);
            MARSDatabase.GetAllTraitsForId(queryResult.DataID, poseProvider, m_PoseTraits);

            db.GetTraitProvider(out MARSTraitDataProvider<UnityEngine.Vector2> vector2Provider);
            MARSDatabase.GetAllTraitsForId(queryResult.DataID, vector2Provider, m_Vector2Traits);
        }

        ///<summary>Get the semanticTag traits</summary>
        public void GetTraits(out Dictionary<string, System.Boolean> traits)
        {
            traits = m_SemanticTagTraits;
        }

        ///<summary>Get the int traits</summary>
        public void GetTraits(out Dictionary<string, System.Int32> traits)
        {
            traits = m_IntTraits;
        }

        ///<summary>Get the float traits</summary>
        public void GetTraits(out Dictionary<string, System.Single> traits)
        {
            traits = m_FloatTraits;
        }

        ///<summary>Get the string traits</summary>
        public void GetTraits(out Dictionary<string, System.String> traits)
        {
            traits = m_StringTraits;
        }

        ///<summary>Get the pose traits</summary>
        public void GetTraits(out Dictionary<string, UnityEngine.Pose> traits)
        {
            traits = m_PoseTraits;
        }

        ///<summary>Get the vector2 traits</summary>
        public void GetTraits(out Dictionary<string, UnityEngine.Vector2> traits)
        {
            traits = m_Vector2Traits;
        }

        ///<summary>Get value of a particular trait by name</summary>
        public bool TryGetTrait(string traitName, out System.Boolean value)
        {
            if(!m_SemanticTagTraits.TryGetValue(traitName, out value))
            {
                value = default;
                return false;
            }

            return true;
        }

        ///<summary>Get value of a particular trait by name</summary>
        public bool TryGetTrait(string traitName, out System.Int32 value)
        {
            if(!m_IntTraits.TryGetValue(traitName, out value))
            {
                value = default;
                return false;
            }

            return true;
        }

        ///<summary>Get value of a particular trait by name</summary>
        public bool TryGetTrait(string traitName, out System.Single value)
        {
            if(!m_FloatTraits.TryGetValue(traitName, out value))
            {
                value = default;
                return false;
            }

            return true;
        }

        ///<summary>Get value of a particular trait by name</summary>
        public bool TryGetTrait(string traitName, out System.String value)
        {
            if(!m_StringTraits.TryGetValue(traitName, out value))
            {
                value = default;
                return false;
            }

            return true;
        }

        ///<summary>Get value of a particular trait by name</summary>
        public bool TryGetTrait(string traitName, out UnityEngine.Pose value)
        {
            if(!m_PoseTraits.TryGetValue(traitName, out value))
            {
                value = default;
                return false;
            }

            return true;
        }

        ///<summary>Get value of a particular trait by name</summary>
        public bool TryGetTrait(string traitName, out UnityEngine.Vector2 value)
        {
            if(!m_Vector2Traits.TryGetValue(traitName, out value))
            {
                value = default;
                return false;
            }

            return true;
        }

        void CollectPotentialRelations(List<Type>[] childRelationTypes, int index)
        {
            GetTraits(out Dictionary<string, System.Boolean> semanticTagTraits);
            CollectPotentialRelationsOfType(semanticTagTraits, childRelationTypes[index], index);

            GetTraits(out Dictionary<string, System.Int32> intTraits);
            CollectPotentialRelationsOfType(intTraits, childRelationTypes[index], index);

            GetTraits(out Dictionary<string, System.Single> floatTraits);
            CollectPotentialRelationsOfType(floatTraits, childRelationTypes[index], index);

            GetTraits(out Dictionary<string, System.String> stringTraits);
            CollectPotentialRelationsOfType(stringTraits, childRelationTypes[index], index);

            GetTraits(out Dictionary<string, UnityEngine.Pose> poseTraits);
            CollectPotentialRelationsOfType(poseTraits, childRelationTypes[index], index);

            GetTraits(out Dictionary<string, UnityEngine.Vector2> vector2Traits);
            CollectPotentialRelationsOfType(vector2Traits, childRelationTypes[index], index);
        }

        /// <summary>
        /// Get potential conditions from this data snapshot
        /// </summary>
        /// <param name="results">The list to store the results. The list is not cleared.</param>
        /// <param name="gameObject">The gameObject that potential conditions will be added to.</param>
        public void GetPotentialConditions(List<PotentialCondition> results, GameObject gameObject)
        {
            GetTraits(out Dictionary<string, System.Boolean> semanticTagTraits);
            CollectPotentialConditions(semanticTagTraits, results, gameObject);

            GetTraits(out Dictionary<string, System.Int32> intTraits);
            CollectPotentialConditions(intTraits, results, gameObject);

            GetTraits(out Dictionary<string, System.Single> floatTraits);
            CollectPotentialConditions(floatTraits, results, gameObject);

            GetTraits(out Dictionary<string, System.String> stringTraits);
            CollectPotentialConditions(stringTraits, results, gameObject);

            GetTraits(out Dictionary<string, UnityEngine.Pose> poseTraits);
            CollectPotentialConditions(poseTraits, results, gameObject);

            GetTraits(out Dictionary<string, UnityEngine.Vector2> vector2Traits);
            CollectPotentialConditions(vector2Traits, results, gameObject);
        }

        /// <summary>
        /// Gets all trait names in this data snapshot.
        /// </summary>
        /// <param name="results">A list to add the results. The list is not cleared. If null, a new list is allocated.</param>
        public void GetAllTraitNames(List<string> results)
        {
            if (results == null)
                results = new List<string>();

            GetTraits(out Dictionary<string, System.Boolean> semanticTagTraits);
            foreach (var trait in semanticTagTraits)
                results.Add(trait.Key);

            GetTraits(out Dictionary<string, System.Int32> intTraits);
            foreach (var trait in intTraits)
                results.Add(trait.Key);

            GetTraits(out Dictionary<string, System.Single> floatTraits);
            foreach (var trait in floatTraits)
                results.Add(trait.Key);

            GetTraits(out Dictionary<string, System.String> stringTraits);
            foreach (var trait in stringTraits)
                results.Add(trait.Key);

            GetTraits(out Dictionary<string, UnityEngine.Pose> poseTraits);
            foreach (var trait in poseTraits)
                results.Add(trait.Key);

            GetTraits(out Dictionary<string, UnityEngine.Vector2> vector2Traits);
            foreach (var trait in vector2Traits)
                results.Add(trait.Key);
        }
    }
}
