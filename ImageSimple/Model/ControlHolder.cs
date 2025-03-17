using DrawGrid.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace ImageSimple.Model
{
    public class ControlHolder
    {
        public CheckBox SplitterDisabled { get; }
        public CheckBox GridDisabled { get; }

        public TextBox SplitterColumns { get; }
        public TextBox SplitterRows { get; }
        public TextBox SplitterThickness { get; }
        public Button SplitterColor { get; }

        public ComboBox GridType { get; }
        public Button GridColor { get; }
        public TextBox GridSize { get; }
        public TextBox GridThickness { get; }
        public TrackBar GridBarXOffset { get; }
        public TrackBar GridBarYOffset { get; }
        public TextBox GridTbXOffset { get; }
        public TextBox GridTbYOffset { get; }

        public TextBox OutputFolder { get; }

        private readonly Main form;
        private readonly Dictionary<Control, Delegate> eventHandlers = new();

        public ControlHolder(Main form)
        {
            this.form = form ?? throw new ArgumentNullException(nameof(form));

            // Initialize controls
            SplitterDisabled = form.cbSplitterDisabled;
            GridDisabled = form.cbGridDisabled;
            SplitterColumns = form.tbSplitterColomns;
            SplitterRows = form.tbSplitterRows;
            SplitterThickness = form.tbSplitterThickness;
            SplitterColor = form.colorSplitter;
            GridType = form.cbGridType;
            GridColor = form.colorGrid;
            GridSize = form.tbGridSize;
            GridThickness = form.tbGridThickness;
            GridBarXOffset = form.tbarXOffset;
            GridBarYOffset = form.tbarYOffset;
            GridTbXOffset = form.tbXOffset;
            GridTbYOffset = form.tbYOffset;
            OutputFolder = form.tbFolderOutput;

            // Store event handlers
            eventHandlers = new Dictionary<Control, Delegate>
            {
                { SplitterDisabled, new EventHandler(form.cbSplitterDisabled_CheckedChanged) },
                { GridDisabled, new EventHandler(form.cbGridDisabled_CheckedChanged) },
                { SplitterColumns, new EventHandler(form.tbSplitterColomns_TextChanged) },
                { SplitterRows, new EventHandler(form.tbSplitterRows_TextChanged) },
                { SplitterThickness, new EventHandler(form.tbSplitterThickness_TextChanged) },
                { GridType, new EventHandler(form.cbGridType_SelectedIndexChanged) },
                { GridSize, new EventHandler(form.tbGridSize_TextChanged) },
                { GridThickness, new EventHandler(form.tbGridThickness_TextChanged) },
                { GridBarXOffset, new EventHandler(form.tbarXOffset_ValueChanged) },
                { GridBarYOffset, new EventHandler(form.tbarYOffset_ValueChanged) }
            };
        }

        public void DisableEvents()
        {
            foreach (var kvp in eventHandlers)
            {
                if (kvp.Key is CheckBox checkBox)
                    checkBox.CheckedChanged -= (EventHandler)kvp.Value;
                else if (kvp.Key is TextBox textBox)
                    textBox.TextChanged -= (EventHandler)kvp.Value;
                else if (kvp.Key is TrackBar trackBar)
                    trackBar.ValueChanged -= (EventHandler)kvp.Value;
                else if (kvp.Key is ComboBox comboBox)
                    comboBox.SelectedIndexChanged -= (EventHandler)kvp.Value;
            }
        }

        public void EnableEvents()
        {
            foreach (var kvp in eventHandlers)
            {
                if (kvp.Key is CheckBox checkBox)
                    checkBox.CheckedChanged += (EventHandler)kvp.Value;
                else if (kvp.Key is TextBox textBox)
                    textBox.TextChanged += (EventHandler)kvp.Value;
                else if (kvp.Key is TrackBar trackBar)
                    trackBar.ValueChanged += (EventHandler)kvp.Value;
                else if (kvp.Key is ComboBox comboBox)
                    comboBox.SelectedIndexChanged += (EventHandler)kvp.Value;
            }
        }
    }
}
