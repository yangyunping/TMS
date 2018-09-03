using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Reflection;
using System.Windows.Forms;

namespace GoldenLady.Standard
{
    /// <summary>
    /// 模板窗体设置
    /// </summary>
    public sealed class TemplateFormSettings
    {
        private int _formHeight = 600;
        private int _formWidth = 800;
        private Color _formBorderColor = Color.Gray;
        private FormWindowState _startWindowState = FormWindowState.Maximized;
        private bool _navigationBarAutoSize = true;
        private int _navigationBarButtonWidth = 150;
        private int _navigationBarButtonHeight = 40;
        private Font _navigationBarButtonTextFont = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
        private Color _navigationBarBackColor = Color.FromArgb(184, 215, 255);
        private Color _navigationBarButtonTextColor = Color.FromArgb(21, 66, 139);
        private string _titleBarText = @"未指定标题";
        private Font _titleBarFont = new Font(@"微软雅黑", 11F, FontStyle.Regular, GraphicsUnit.Point, 134);
        private Color _titleBarFontColor = Color.FromArgb(21, 66, 139);
        private Color _titleBarBackColor1 = Color.AntiqueWhite;
        private Color _titleBarBackColor2 = Color.BurlyWood;
        private LinearGradientMode _titleBarBackColorLinearGradientMode = LinearGradientMode.Vertical;
        private Color _workSpaceBackColor = SystemColors.Control;
        private Color _workSpaceCollapseBarColor = Color.White;
        private Color _workSpaceToolBarColor = Color.LightBlue;
        private Color _workSpaceToolBarButtonTextColor = Color.Navy;
        private Font _workSpaceToolBarButtonTextFont = new Font("微软雅黑", 11F, FontStyle.Regular, GraphicsUnit.Point, 134);
        private Color _workSpaceToolBarButtonMouseOverColor = Color.Pink;
        private Color _workSpaceToolBarButtonMouseDownColor = Color.LightSteelBlue;
        private int _workSpaceToolBarHeight = 50;
        private int _workSpaceToolBarButtonWidth = 100;
        private NavigationButton[] _navigationButtons = { };


        /// <summary>
        /// 窗体宽度
        /// </summary>
        public int FormWidth
        {
            get { return _formWidth; }
            set { _formWidth = value; }
        }
        /// <summary>
        /// 窗体高度
        /// </summary>
        public int FormHeight
        {
            get { return _formHeight; }
            set { _formHeight = value; }
        }
        /// <summary>
        /// 窗体边框厚度
        /// </summary>
        public int FormBorderThickness { get; set; }
        /// <summary>
        /// 窗体边框颜色
        /// </summary>
        public Color FormBorderColor
        {
            get { return _formBorderColor; }
            set { _formBorderColor = value; }
        }
        /// <summary>
        /// 窗体刚打开时的状态
        /// </summary>
        public FormWindowState StartWindowState
        {
            get { return _startWindowState; }
            set { _startWindowState = value; }
        }
        /// <summary>
        /// 导航栏按钮组
        /// </summary>
        public NavigationButton[] NavigationButtons
        {
            get { return _navigationButtons; }
            set { _navigationButtons = value; }
        }
        /// <summary>
        /// 是否自动根据导航栏中按钮文字的大小自动调整按钮的大小
        /// </summary>
        public bool NavigationBarAutoSize
        {
            get { return _navigationBarAutoSize; }
            set { _navigationBarAutoSize = value; }
        }
        /// <summary>
        /// 导航栏按钮宽度
        /// </summary>
        public int NavigationBarButtonWidth
        {
            get { return _navigationBarButtonWidth; }
            set { _navigationBarButtonWidth = value; }
        }
        /// <summary>
        /// 导航栏按钮高度
        /// </summary>
        public int NavigationBarButtonHeight
        {
            get { return _navigationBarButtonHeight; }
            set { _navigationBarButtonHeight = value; }
        }
        /// <summary>
        /// 导航栏按钮文字字体
        /// </summary>
        public Font NavigationBarButtonTextFont
        {
            get { return _navigationBarButtonTextFont; }
            set { _navigationBarButtonTextFont = value; }
        }
        /// <summary>
        /// 导航栏背景色
        /// </summary>
        public Color NavigationBarBackColor
        {
            get { return _navigationBarBackColor; }
            set { _navigationBarBackColor = value; }
        }
        /// <summary>
        /// 导航栏按钮文字颜色
        /// </summary>
        public Color NavigationBarButtonTextColor
        {
            get { return _navigationBarButtonTextColor; }
            set { _navigationBarButtonTextColor = value; }
        }
        /// <summary>
        /// 标题栏内容
        /// </summary>
        public string TitleBarText
        {
            get { return _titleBarText; }
            set { _titleBarText = value; }
        }
        /// <summary>
        /// 标题栏字体
        /// </summary>
        public Font TitleBarFont
        {
            get { return _titleBarFont; }
            set { _titleBarFont = value; }
        }
        /// <summary>
        /// 标题栏字体颜色
        /// </summary>
        public Color TitleBarFontColor
        {
            get { return _titleBarFontColor; }
            set { _titleBarFontColor = value; }
        }
        /// <summary>
        /// 标题栏背景渐变颜色1
        /// </summary>
        public Color TitleBarBackColor1
        {
            get { return _titleBarBackColor1; }
            set { _titleBarBackColor1 = value; }
        }
        /// <summary>
        /// 标题栏背景渐变颜色2
        /// </summary>
        public Color TitleBarBackColor2
        {
            get { return _titleBarBackColor2; }
            set { _titleBarBackColor2 = value; }
        }
        /// <summary>
        /// 标题栏背景渐变颜色模式
        /// </summary>
        public LinearGradientMode TitleBarBackColorLinearGradientMode
        {
            get { return _titleBarBackColorLinearGradientMode; }
            set { _titleBarBackColorLinearGradientMode = value; }
        }
        /// <summary>
        /// 工作区背景色
        /// </summary>
        public Color WorkSpaceBackColor
        {
            get { return _workSpaceBackColor; }
            set { _workSpaceBackColor = value; }
        }
        /// <summary>
        /// 工作区扩展条颜色
        /// </summary>
        public Color WorkSpaceCollapseBarColor
        {
            get { return _workSpaceCollapseBarColor; }
            set { _workSpaceCollapseBarColor = value; }
        }
        /// <summary>
        /// 工作区工具栏颜色（从工作区背景色水平渐变）
        /// </summary>
        public Color WorkSpaceToolBarColor
        {
            get { return _workSpaceToolBarColor; }
            set { _workSpaceToolBarColor = value; }
        }
        /// <summary>
        /// 工作区工具栏高度
        /// </summary>
        public int WorkSpaceToolBarHeight
        {
            get { return _workSpaceToolBarHeight; }
            set { _workSpaceToolBarHeight = value; }
        }
        /// <summary>
        /// 工作区工具栏按钮宽度
        /// </summary>
        public int WorkSpaceToolBarButtonWidth
        {
            get { return _workSpaceToolBarButtonWidth; }
            set { _workSpaceToolBarButtonWidth = value; }
        }
        /// <summary>
        /// 工作区工具栏按钮文本颜色
        /// </summary>
        public Color WorkSpaceToolBarButtonTextColor
        {
            get { return _workSpaceToolBarButtonTextColor; }
            set { _workSpaceToolBarButtonTextColor = value; }
        }
        /// <summary>
        /// 工作区工具栏按钮在鼠标放上去时的颜色
        /// </summary>
        public Color WorkSpaceToolBarButtonMouseOverColor
        {
            get { return _workSpaceToolBarButtonMouseOverColor; }
            set { _workSpaceToolBarButtonMouseOverColor = value; }
        }
        /// <summary>
        /// 工作区工具栏按钮在鼠标按下时的颜色
        /// </summary>
        public Color WorkSpaceToolBarButtonMouseDownColor
        {
            get { return _workSpaceToolBarButtonMouseDownColor; }
            set { _workSpaceToolBarButtonMouseDownColor = value; }
        }
        /// <summary>
        /// 工作区工具栏按钮文本字体
        /// </summary>
        public Font WorkSpaceToolBarButtonTextFont
        {
            get { return _workSpaceToolBarButtonTextFont; }
            set { _workSpaceToolBarButtonTextFont = value; }
        }
        /// <summary>
        /// 是否启用工作区缓存，默认不启用
        /// </summary>
        public bool WorkSpaceCacheEnabled { get; set; }
    }

    /// <summary>
    /// 模板窗体导航栏按钮
    /// </summary>
    public sealed class NavigationButton
    {
        /// <summary>
        /// 按钮显示的文字
        /// </summary>
        public string Text { get; private set; }
        /// <summary>
        /// 按钮点击后的处理形式
        /// </summary>
        public NavigationButtonHandle Click { get; private set; }
        /// <summary>
        /// 要打开的目标窗体或用户控件的类型
        /// </summary>
        public Type TargetType { get; private set; }
        /// <summary>
        /// 工具栏按钮组
        /// </summary>
        public ToolButton[] ToolButtons { get; private set; }
        /// <summary>
        /// 点击按钮要执行的方法
        /// </summary>
        public Action ExecuteMethod { get; private set; }
        /// <summary>
        /// 目标对象构造时所需的参数
        /// </summary>
        public object[] ConstructorParams { get; private set; }

        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="text">按钮显示的文字</param>
        /// <param name="handle">按钮点击后的处理形式</param>
        /// <param name="targetType">要打开的目标窗体或用户控件的类型</param>
        /// <param name="constructorParams">目标对象构造时所需的参数</param>
        /// <param name="toolButtons">工具栏按钮组</param>
        public NavigationButton(string text, NavigationButtonHandle handle, Type targetType, object[] constructorParams, ToolButton[] toolButtons)
        {
            Text = text;
            Click = handle;
            TargetType = targetType;
            ConstructorParams = constructorParams;
            ToolButtons = toolButtons;
            ExecuteMethod = null;
        }
        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="text">按钮显示的文字</param>
        /// <param name="handle">按钮点击后的处理形式</param>
        /// <param name="targetType">要打开的目标窗体或用户控件的类型</param>
        /// <param name="toolButtons">工具栏按钮组</param>
        public NavigationButton(string text, NavigationButtonHandle handle, Type targetType, ToolButton[] toolButtons) : this(text, handle, targetType, null, toolButtons) { }
        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="text">按钮显示的文字</param>
        /// <param name="handle">按钮点击后的处理形式</param>
        /// <param name="targetType">要打开的目标窗体或用户控件的类型</param>
        public NavigationButton(string text, NavigationButtonHandle handle, Type targetType)
            : this(text, handle, targetType, null, new ToolButton[] { }) { }
        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="text">按钮显示的文字</param>
        /// <param name="handle">按钮点击后的处理形式</param>
        /// <param name="targetType">要打开的目标窗体或用户控件的类型</param>
        /// <param name="constructorParams">目标对象构造时所需的参数</param>
        public NavigationButton(string text, NavigationButtonHandle handle, Type targetType, object[] constructorParams)
            : this(text, handle, targetType, constructorParams, new ToolButton[] { }) { }
        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="text">按钮显示的文字</param>
        /// <param name="method">点击后要执行的方法</param>
        public NavigationButton(string text, Action method)
        {
            Text = text;
            Click = NavigationButtonHandle.ExecuteMethod;
            ExecuteMethod = method;
        }
    }

    /// <summary>
    /// 模板窗体工具栏按钮
    /// </summary>
    public sealed class ToolButton
    {
        /// <summary>
        /// 按钮显示的文字
        /// </summary>
        public string Text { get; private set; }
        /// <summary>
        /// 点击按钮要调用的方法名
        /// </summary>
        public string ClickMethodName { get; private set; }
        /// <summary>
        /// 方法属性
        /// </summary>
        public BindingFlags Flags { get; private set; }
        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="text">按钮显示的文字</param>
        /// <param name="clickMethodName">点击按钮要调用的方法名</param>
        /// <param name="flags">方法属性</param>
        public ToolButton(string text, string clickMethodName, BindingFlags flags = BindingFlags.Default)
        {
            Text = text;
            ClickMethodName = clickMethodName;
            Flags = flags;
        }
    }

    /// <summary>
    /// 点击模板窗体导航栏后的处理形式
    /// </summary>
    public enum NavigationButtonHandle
    {
        /// <summary>
        /// 在工作区打开
        /// </summary>
        OpenInWorkSpace,
        /// <summary>
        /// 打开模态对话框
        /// </summary>
        OpenFormModal,
        /// <summary>
        /// 打开非模态对话框
        /// </summary>
        OpenFormNonModal,
        /// <summary>
        /// 执行一个方法
        /// </summary>
        ExecuteMethod
    }
    /// <summary>
    /// 如果放入工作区的某个窗体或用户控件在运行时工具栏上的按钮需要即时变动，请实现本接口
    /// </summary>
    public interface IMultiToolBar
    {
        /// <summary>
        /// 按要求重置工具栏的委托
        /// </summary>
        Action<IEnumerable<ToolButton>> ResetToolBarAction { get; set; }
    }
}