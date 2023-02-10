﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Toolbox.Library.NodeWrappers;
using Toolbox.Library.Animations;
using Toolbox.Library.Forms;
using Toolbox.Library;
using ResU = Syroot.NintenTools.Bfres;
using ResNX = Syroot.NintenTools.NSW.Bfres;
using FirstPlugin;

namespace Bfres.Structs
{
    public class BFRESAnimFolder : STGenericWrapper, IContextMenuNode
    {
        public BFRESAnimFolder()
        {
            Text = "Animations";
        }

        public bool IsWiiU { get; set; }

        public override void OnClick(TreeView treeview)
        {
            if (Parent is BFRES)
                ((BFRES)Parent).LoadEditors(this);
            else if (Parent.Parent is BFRES)
            {
                ((BFRES)Parent.Parent).LoadEditors(this);
            }
            else
            {
                ((BFRES)Parent.Parent.Parent).LoadEditors(this);
            }
        }

        public ResNX.ResFile GetResFile()
        {
            return ((BFRES)Parent).resFile;
        }

        public ResU.ResFile GetResFileU()
        {
            return ((BFRES)Parent).resFileU;
        }

        public void AddNode(BFRESGroupNode node)
        {
            Nodes.Add(node);
        }

        public void LoadMenus(bool isWiiUBfres)
        {
            IsWiiU = isWiiUBfres;
        }

        public ToolStripItem[] GetContextMenuItems()
        {
            List<ToolStripItem> Items = new List<ToolStripItem>();
            Items.Add(new ToolStripMenuItem("新建", null,
                           new ToolStripMenuItem("骨骼动画", null, NewSkeletalAnimAction),
                           new ToolStripMenuItem("着色器参数动画", null, NewShaderParamAnimAction),
                           new ToolStripMenuItem("色彩动画", null, NewColorAnimAction),
                           new ToolStripMenuItem("纹理 SRT 动画", null, NewTexSrtAnimAction),
                           new ToolStripMenuItem("纹理图案动画", null, NewTexPatAnimAction),
                           new ToolStripMenuItem("骨骼可见性动画", null, NewBoneVisAnimAction),
                           new ToolStripMenuItem("材质可见性动画", null, NewMatVisAnimAction),
                           new ToolStripMenuItem("形变动画", null, NewShapeAnimAction),
                           new ToolStripMenuItem("场景动画", null, NewSceneAnimAction)
                       ));

            Items.Add(new ToolStripMenuItem("导入", null,
              new ToolStripMenuItem("骨骼动画", null, ImportSkeletalAnimAction),
              new ToolStripMenuItem("着色器参数动画", null, ImportShaderParamAnimAction),
              new ToolStripMenuItem("色彩动画", null, ImportColorAnimAction),
              new ToolStripMenuItem("纹理 SRT 动画", null, ImportTexSrtAnimAction),
              new ToolStripMenuItem("纹理图案动画", null, ImportTexPatAnimAction),
              new ToolStripMenuItem("骨骼可见性动画", null, ImportBoneVisAnimAction),
              new ToolStripMenuItem("材质可见性动画", null, ImportMatVisAnimAction),
              new ToolStripMenuItem("形变动画", null, ImportShapeAnimAction),
              new ToolStripMenuItem("场景动画", null, ImportSceneAnimAction)
              ));

            Items.Add(new ToolStripMenuItem("清除", null, ClearAction, Keys.Control | Keys.C));

            return Items.ToArray();
        }


        protected void NewSkeletalAnimAction(object sender, EventArgs e) { NewSkeletalAnim(); }
        protected void NewShaderParamAnimAction(object sender, EventArgs e) { NewShaderParamAnim(); }
        protected void NewColorAnimAction(object sender, EventArgs e) { NewColorAnim(); }
        protected void NewTexSrtAnimAction(object sender, EventArgs e) { NewTexSrtAnim(); }
        protected void NewTexPatAnimAction(object sender, EventArgs e) { NewTexPatAnim(); }
        protected void NewBoneVisAnimAction(object sender, EventArgs e) { NewBoneVisAnim(); }
        protected void NewMatVisAnimAction(object sender, EventArgs e) { NewMatVisAnim(); }
        protected void NewShapeAnimAction(object sender, EventArgs e) { NewShapeAnim(); }
        protected void NewSceneAnimAction(object sender, EventArgs e) { NewSceneAnim(); }

        protected void ImportSkeletalAnimAction(object sender, EventArgs e) { ImportSkeletalAnim(); }
        protected void ImportShaderParamAnimAction(object sender, EventArgs e) { ImportShaderParamAnim(); }
        protected void ImportColorAnimAction(object sender, EventArgs e) { ImportColorAnim(); }
        protected void ImportTexSrtAnimAction(object sender, EventArgs e) { ImportTexSrtAnim(); }
        protected void ImportTexPatAnimAction(object sender, EventArgs e) { ImportTexPatAnim(); }
        protected void ImportBoneVisAnimAction(object sender, EventArgs e) { ImportBoneVisAnim(); }
        protected void ImportMatVisAnimAction(object sender, EventArgs e) { ImportMatVisAnim(); }
        protected void ImportShapeAnimAction(object sender, EventArgs e) { ImportShapeAnim(); }
        protected void ImportSceneAnimAction(object sender, EventArgs e) { ImportSceneAnim(); }

        public void ImportSkeletalAnim()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = FileFilters.FSKA_REPLACE;
            ofd.Multiselect = true;

            if (ofd.ShowDialog() != DialogResult.OK)
                return;

            BFRESGroupNode group = GetOrCreateFolder<FSKA>();
            group.Import(ofd.FileNames, GetResFile(), GetResFileU());
            AddFolder(group);
        }

        public void ImportShaderParamAnim()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (IsWiiU)
                ofd.Filter = FileFilters.GetFilter(typeof(FSHU), MaterialAnimation.AnimationType.ShaderParam);
            else
                ofd.Filter = FileFilters.FMAA;
            ofd.Multiselect = true;

            if (ofd.ShowDialog() != DialogResult.OK)
                return;

            BFRESGroupNode group = null;
            if (IsWiiU)
                group = GetOrCreateFolder<FSHU>(MaterialAnimation.AnimationType.ShaderParam);
            else
                group = GetOrCreateFolder<FMAA>(MaterialAnimation.AnimationType.ShaderParam);

            group.Import(ofd.FileNames, GetResFile(), GetResFileU());
            AddFolder(group);
        }

        public void ImportColorAnim()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (IsWiiU)
                ofd.Filter = FileFilters.GetFilter(typeof(FSHU), MaterialAnimation.AnimationType.Color);
            else
                ofd.Filter = FileFilters.FMAA;
            ofd.Multiselect = true;

            if (ofd.ShowDialog() != DialogResult.OK)
                return;

            BFRESGroupNode group = null;
            if (IsWiiU)
                group = GetOrCreateFolder<FSHU>(MaterialAnimation.AnimationType.Color);
            else
                group = GetOrCreateFolder<FMAA>(MaterialAnimation.AnimationType.Color);

            group.Import(ofd.FileNames, GetResFile(), GetResFileU());
            AddFolder(group);
        }

        public void ImportTexSrtAnim()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (IsWiiU)
                ofd.Filter = FileFilters.GetFilter(typeof(FSHU), MaterialAnimation.AnimationType.TextureSrt);
            else
                ofd.Filter = FileFilters.FMAA;
            ofd.Multiselect = true;

            if (ofd.ShowDialog() != DialogResult.OK)
                return;

            BFRESGroupNode group = null;
            if (IsWiiU)
                group = GetOrCreateFolder<FSHU>(MaterialAnimation.AnimationType.TextureSrt);
            else
                group = GetOrCreateFolder<FMAA>(MaterialAnimation.AnimationType.TextureSrt);

            group.Import(ofd.FileNames, GetResFile(), GetResFileU());
            AddFolder(group);
        }

        public void ImportTexPatAnim()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (IsWiiU)
                ofd.Filter = FileFilters.FTXP;
            else
                ofd.Filter = FileFilters.FMAA;
            ofd.Multiselect = true;

            if (ofd.ShowDialog() != DialogResult.OK)
                return;

            BFRESGroupNode group = null;
            if (IsWiiU)
                group = GetOrCreateFolder<FTXP>();
            else
                group = GetOrCreateFolder<FMAA>(MaterialAnimation.AnimationType.TexturePattern);

            group.Import(ofd.FileNames, GetResFile(), GetResFileU());
            AddFolder(group);
        }

        public void ImportBoneVisAnim()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = FileFilters.FBNV;
            ofd.Multiselect = true;

            if (ofd.ShowDialog() != DialogResult.OK)
                return;

            BFRESGroupNode group = GetOrCreateFolder<FVIS>(VisibiltyAnimType.Bone);
            group.Import(ofd.FileNames, GetResFile(), GetResFileU());
            AddFolder(group);
        }

        public void ImportMatVisAnim()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = FileFilters.FBNV;
            ofd.Multiselect = true;

            if (ofd.ShowDialog() != DialogResult.OK)
                return;

            BFRESGroupNode group = null;
            if (IsWiiU)
                group = GetOrCreateFolder<FVIS>(VisibiltyAnimType.Material);
            else
                group = GetOrCreateFolder<FMAA>(MaterialAnimation.AnimationType.Visibilty);

            group.Import(ofd.FileNames, GetResFile(), GetResFileU());
            AddFolder(group);
        }

        public void ImportSceneAnim()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = FileFilters.FSCN;
            ofd.Multiselect = true;

            if (ofd.ShowDialog() != DialogResult.OK)
                return;

            BFRESGroupNode group = GetOrCreateFolder<FSCN>();
            group.Import(ofd.FileNames, GetResFile(), GetResFileU());
            AddFolder(group);
        }

        public void ImportShapeAnim()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = FileFilters.FSHA;
            ofd.Multiselect = true;

            if (ofd.ShowDialog() != DialogResult.OK)
                return;

            BFRESGroupNode group = GetOrCreateFolder<FSHA>();
            group.Import(ofd.FileNames, GetResFile(), GetResFileU());
            AddFolder(group);
        }
        public void NewSkeletalAnim()
        {
            BFRESGroupNode group = GetOrCreateFolder<FSKA>();
            FSKA anim = null;
            if (IsWiiU)
                anim = new FSKA(new ResU.SkeletalAnim());
            else
                anim = new FSKA(new ResNX.SkeletalAnim());

            group.AddNode(anim, "NewSkeletalAnim");
            AddFolder(group);
        }

        public void NewShaderParamAnim()
        {
            var type = MaterialAnimation.AnimationType.ShaderParam;

            BFRESGroupNode group = null;
            if (IsWiiU)
            {
                group = GetOrCreateFolder<FSHU>(type);
                FSHU fshu = new FSHU(new ResU.ShaderParamAnim(), type);
                group.AddNode(fshu, "NewShaderParamAnim_fsp");
            }
            else
            {
                group = GetOrCreateFolder<FMAA>(type);
                FMAA fmaa = new FMAA(new ResNX.MaterialAnim());
                group.AddNode(fmaa, "NewShaderParamAnim_fsp");
            }

            AddFolder(group);
        }

        public void NewColorAnim()
        {
            var type = MaterialAnimation.AnimationType.Color;

            BFRESGroupNode group = null;
            if (IsWiiU)
            {
                group = GetOrCreateFolder<FSHU>(type);
                FSHU fshu = new FSHU(new ResU.ShaderParamAnim(), type);
                group.AddNode(fshu, "NewColorAnim_fcl");
            }
            else
            {
                group = GetOrCreateFolder<FMAA>(type);
                FMAA fmaa = new FMAA(new ResNX.MaterialAnim());
                group.AddNode(fmaa, "NewColorAnim_fcl");
            }

            AddFolder(group);
        }

        public void NewTexSrtAnim()
        {
            var type = MaterialAnimation.AnimationType.TextureSrt;

            BFRESGroupNode group = null;
            if (IsWiiU)
            {
                group = GetOrCreateFolder<FSHU>(type);
                FSHU fshu = new FSHU(new ResU.ShaderParamAnim(), type);
                group.AddNode(fshu, "NewTextureTransformAnim_fts");
            }
            else
            {
                group = GetOrCreateFolder<FMAA>(type);
                FMAA fmaa = new FMAA(new ResNX.MaterialAnim());
                group.AddNode(fmaa, "NewTextureTransformAnim_fts");
            }

            AddFolder(group);
        }

        public void NewTexPatAnim()
        {
            var type = MaterialAnimation.AnimationType.TexturePattern;

            BFRESGroupNode group = null;
            if (IsWiiU)
            {
                group = GetOrCreateFolder<FTXP>();
                FTXP anim = new FTXP(new ResU.TexPatternAnim());
                group.AddNode(anim, "NewTexturePatternAnim_ftp");
            }
            else
            {
                group = GetOrCreateFolder<FMAA>(type);
                FMAA fmaa = new FMAA(new ResNX.MaterialAnim());
                group.AddNode(fmaa, "NewTexturePatternAnim_ftp");
            }

            AddFolder(group);
        }

        public void NewBoneVisAnim()
        {
            BFRESGroupNode group = GetOrCreateFolder<FVIS>(VisibiltyAnimType.Bone);

            FVIS anim = null;
            if (IsWiiU)
            {
                anim = new FVIS(new ResU.VisibilityAnim() { Type = ResU.VisibilityAnimType.Bone });
            }
            else
            {
                anim = new FVIS(new ResNX.VisibilityAnim());
            }

            group.AddNode(anim, "NewBoneVisAnim");
            AddFolder(group);
        }

        public void NewMatVisAnim()
        {
            BFRESGroupNode group = null;
            if (IsWiiU)
            {
                group = GetOrCreateFolder<FVIS>(VisibiltyAnimType.Material);
                FVIS anim = new FVIS(new ResU.VisibilityAnim() { Type = ResU.VisibilityAnimType.Material });
                group.AddNode(anim, "NewMatVisAnim_fvm");
            }
            else
            {
                group = GetOrCreateFolder<FMAA>(MaterialAnimation.AnimationType.Visibilty);
                FMAA fmaa = new FMAA(new ResNX.MaterialAnim());
                group.AddNode(fmaa, "NewMatVisAnim_fvm");
            }

            AddFolder(group);
        }

        public void NewShapeAnim()
        {
            BFRESGroupNode group = GetOrCreateFolder<FSHA>();
            FSHA anim = null;
            if (IsWiiU)
                anim = new FSHA(new ResU.ShapeAnim());
            else
                anim = new FSHA(new ResNX.ShapeAnim());

            group.AddNode(anim, "NewShapeAnim");
            AddFolder(group);
        }

        public void NewSceneAnim()
        {
            BFRESGroupNode group = GetOrCreateFolder<FSCN>();
            FSCN fshu = null;
            if (IsWiiU)
                fshu = new FSCN(new ResU.SceneAnim());
            else
                fshu = new FSCN(new ResNX.SceneAnim());

            group.AddNode(fshu, "NewSceneVisAnim");
            AddFolder(group);
        }

        private void AddFolder(BFRESGroupNode group)
        {
            if (!Nodes.Contains(group))
                Nodes.Add(group);
        }

        public BFRESGroupNode GetOrCreateFolder<T>(object CheckAnimEffect = null) where T : STGenericWrapper
        {
            BFRESGroupNode group = new BFRESGroupNode(IsWiiU);

            if (typeof(T) == typeof(FSKA)) { group.Type = BRESGroupType.SkeletalAnim; }
            if (typeof(T) == typeof(FMAA)) { group.Type = BRESGroupType.MaterialAnim; }
            if (typeof(T) == typeof(FSHU)) { group.Type = BRESGroupType.ShaderParamAnim; }
            if (typeof(T) == typeof(FVIS)) { group.Type = BRESGroupType.BoneVisAnim; }
            if (typeof(T) == typeof(FSHA)) { group.Type = BRESGroupType.ShapeAnim; }
            if (typeof(T) == typeof(FSCN)) { group.Type = BRESGroupType.SceneAnim; }
            if (typeof(T) == typeof(FTXP)) { group.Type = BRESGroupType.TexPatAnim; }

            if (CheckAnimEffect != null)
            {
                if (CheckAnimEffect is MaterialAnimation.AnimationType)
                {
                    var type = (MaterialAnimation.AnimationType)CheckAnimEffect;

                    if (type == MaterialAnimation.AnimationType.Color) { group.Type = BRESGroupType.ColorAnim; }
                    if (type == MaterialAnimation.AnimationType.TextureSrt) { group.Type = BRESGroupType.TexSrtAnim; }
                    if (type == MaterialAnimation.AnimationType.ShaderParam) { group.Type = BRESGroupType.ShaderParamAnim; }
                    if (type == MaterialAnimation.AnimationType.TexturePattern) { group.Type = BRESGroupType.TexPatAnim; }
                    if (type == MaterialAnimation.AnimationType.Visibilty) { group.Type = BRESGroupType.MatVisAnim; }
                }
                if (CheckAnimEffect is VisibiltyAnimType)
                {
                    var type = (VisibiltyAnimType)CheckAnimEffect;

                    if (type == VisibiltyAnimType.Bone) { group.Type = BRESGroupType.BoneVisAnim; }
                    if (type == VisibiltyAnimType.Material) { group.Type = BRESGroupType.MatVisAnim; }
                }
            }
            group.SetNameByType();

            foreach (BFRESGroupNode node in Nodes)
            {
                if (node.Type == group.Type)
                    return node;
            }

            return group;
        }
    }
}
