﻿// Author: Daniele Giardini - http://www.demigiant.com
// Created: 2017/03/09 11:43
// License Copyright (c) Daniele Giardini

using DG.DeExtensions;
using DG.DemiEditor.DeGUINodeSystem;
using UnityEditor;
using UnityEngine;
using _Examples.DeGUI.DeGUINode;

namespace _Examples.DeGUI.Editor.DeGUINode
{
    public class DeGUINodeSampler : EditorWindow
    {
        const string _Title = "DeGUINodeSampler";
        static DeSampler src;
        NodeProcess _nodeProcess;

        #region Open

        public static void ShowWindow(DeSampler src)
        {
            DeGUINodeSampler.src = src;
            EditorWindow editor = GetWindow(typeof(DeGUINodeSampler), true, _Title);
            Undo.undoRedoPerformed -= editor.Repaint;
            Undo.undoRedoPerformed += editor.Repaint;
        }

        #endregion

        #region Unity and GUI Methods

        void OnEnable()
        {
            if (src == null) {
                Close();
                return;
            }
            _nodeProcess = new NodeProcess(this);
        }

        void OnHierarchyChange()
        { Repaint(); }

        void OnDestroy() { Undo.undoRedoPerformed -= Repaint; }

        void OnGUI()
        {
            if (src == null) {
                Close();
                return;
            }

            Undo.RecordObject(src, "DeSampler");
            DG.DemiEditor.DeGUI.BeginGUI();

            // Node GUI Process
            using (new NodeProcessScope<GenericNode>(_nodeProcess, this.position.ResetXY(), ref src.nodeSystem.areaShift, src.nodeSystem.genericNodes)) {
                // EVENTS
                switch (_nodeProcess.interaction.state) {
                case InteractionManager.State.ContextClick:
                    switch (_nodeProcess.interaction.mouseTargetType) {
                    case InteractionManager.TargetType.Background:
                        Debug.Log("ContextClick > Background");
                        break;
                    case InteractionManager.TargetType.Node:
                        if (_nodeProcess.selection.selectedNodes.Count == 0) Debug.Log("ContextClick > Unselected node");
                        else if (_nodeProcess.selection.selectedNodes.Count == 1) Debug.Log("ContextClick > Single selected node");
                        else Debug.Log("ContextClick > Multiple selected nodes");
                        break;
                    }
                    break;
                case InteractionManager.State.DoubleClick:
                    Debug.Log("<color=#00ff00>DoubleClick > " + _nodeProcess.interaction.mouseTargetType + (_nodeProcess.interaction.targetNode == null ? "" : " > " + _nodeProcess.interaction.targetNode.id) + "</color>");
                    break;
                }

                // Draw nodes
                // Generic nodes
                foreach (GenericNode node in src.nodeSystem.genericNodes) {
                    _nodeProcess.Draw<GenericNodeGUI>(node);
                }
                // Start node (last so it's always over other nodes)
                _nodeProcess.Draw<StartNodeGUI>(src.nodeSystem.startNode);
            }

            if (GUI.changed) EditorUtility.SetDirty(src);
        }

        #endregion
    }
}