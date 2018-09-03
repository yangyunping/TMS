using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using GoldenLady.Dress.Utils;
using GoldenLady.Dress.View.Template;
using GoldenLady.Standard.Dress;

namespace GoldenLady.Dress.View
{
    /// <summary>
    /// 选择礼服区域的窗口
    /// LiuHaiyang
    /// 2017.4.27
    /// </summary>
    public partial class FrmAreaPicker : FrmBackWork
    {
        public Action<TreeNode> AfterPick { get; set; }

        public FrmAreaPicker()
        {
            InitializeComponent();
        }
        private void InitData()
        {
            IEnumerable<RuleObject> rules = DressManager.GetRules();
            IEnumerable<RuleObject> areaRoots = rules.Where(r => !string.IsNullOrWhiteSpace(r.BindingNo));
            foreach(RuleObject areaRoot in areaRoots)
            {
                TreeNode root = tvwArea.Nodes.Add(areaRoot.Name);
                root.Tag = areaRoot;
                FindChild(root, rules);
            }
        }
        private static void FindChild(TreeNode node, IEnumerable<RuleObject> rules)
        {
            RuleObject current = (RuleObject)node.Tag;
            foreach(RuleObject rule in rules.Where(r=>r.ParentRuleNo == current.RuleNo && !r.Name.EndsWith(@"区1") && r.Name != @"首尔印象区"))
            {
                TreeNode child = node.Nodes.Add(rule.Name);
                child.Tag = rule;
                FindChild(child, rules);
            }
        }

        private void FrmAreaPicker_Load(object sender, EventArgs e)
        {
            InitData();
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            if(null == tvwArea.SelectedNode)
            {
                return;
            }
            if(null != AfterPick)
            {
                AfterPick(tvwArea.SelectedNode);
            }
            Close();
        }
    }
}