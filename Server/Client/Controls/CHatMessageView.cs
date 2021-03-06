﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.Controls {
    sealed class ChatMessageView : UserControl {
        public enum MessageDirection {
            Incoming, Outgoing
        }

        private readonly Label m_lblMessage = new Label();
        private readonly Label m_lblSender = new Label();

        private String m_strMessage;
        private String m_strSender;
        private DateTime m_dtWhen;

        public string Message {
            get {
                return m_strMessage;
            }
            set {
                m_lblMessage.Text = value;
                m_strMessage = value;
            }
        }

        public string Sender {
            get {
                return m_strSender;
            }
            set {
                m_lblSender.Text = string.Format("{0} says:", value);
                m_strSender = value;
            }
        }

        public DateTime When {
            get {
                return m_dtWhen;
            }
            set {
                m_dtWhen = value;
            }
        }

        public MessageDirection MsgDirection {
            get; set; }

        public ChatMessageView(MessageDirection msgDirection, String msg, String sender, DateTime when) {
            Message = msg;
            Sender = sender;
            When = when;
            MsgDirection = msgDirection;

            var ftMessage = new Font("Arial", 12);

            m_lblSender.AutoSize = true;
            m_lblSender.Dock = DockStyle.Top;
            m_lblSender.Text = String.Format("{0} sagt: ", sender);
            m_lblSender.Height = 20;
            m_lblSender.BackColor = Color.Transparent;
            m_lblSender.ForeColor = Color.White;
            m_lblSender.Font = new Font(ftMessage, FontStyle.Bold);
            this.Controls.Add(m_lblSender);

            m_lblMessage.AutoSize = true;
            m_lblMessage.MaximumSize = new Size(400, 1000);
            m_lblMessage.Location = new Point(0, 22);
            m_lblMessage.TextAlign = ContentAlignment.TopLeft;
            m_lblMessage.Font = ftMessage;
            m_lblMessage.ForeColor = Color.White;
            m_lblMessage.BackColor = Color.Transparent;
            this.Controls.Add(m_lblMessage);

            this.BackColor = Color.White;
            this.Height = m_lblMessage.Height + m_lblSender.Height + 28;
            this.Width = m_lblMessage.Width + 10;
            this.MinimumSize = new Size(300, 28);
            this.Padding = new Padding(5);
            this.Margin = new Padding(5);
            if (msgDirection == MessageDirection.Incoming) {
                this.Padding = new Padding(40, 5, 40, 5);
                this.Width = m_lblMessage.Width + 40;
            }
        }

        protected override void OnPaint(PaintEventArgs e) {
            base.OnPaint(e);
            var blendBrush = new LinearGradientBrush(new Rectangle(0, 0, this.Width, this.Height + 100),
                Color.DarkGreen, Color.Green, 45f);
            e.Graphics.FillRectangle(blendBrush, 0, 0, Width, Height);
            e.Graphics.DrawRectangle(Pens.ForestGreen, 0, 0, Width -1 , Height -1);
            blendBrush.Dispose();

            //DrawRoundRect(e.Graphics, Pens.Silver, blendBrush, this.Padding.All, this.Padding.All,
            //              m_lblMessage.Width + this.Padding.All + 10, this.Height - 10, 4);
        }

        public void DrawRoundRect(Graphics g, Pen p, Brush brushFill, float x, float y, float width, float height, float radius) {
            var gp = new GraphicsPath();
            gp.AddLine(x + radius, y, x + width - (radius * 2), y);
            gp.AddArc(x + width - (radius * 2), y, radius * 2, radius * 2, 270, 90);
            gp.AddLine(x + width, y + radius, x + width, y + height - (radius * 2));
            gp.AddArc(x + width - (radius * 2), y + height - (radius * 2), radius * 2, radius * 2, 0, 90);
            gp.AddLine(x + width - (radius * 2), y + height, x + radius, y + height);
            gp.AddArc(x, y + height - (radius * 2), radius * 2, radius * 2, 90, 90);
            gp.AddLine(x, y + height - (radius * 2), x, y + radius);
            gp.AddArc(x, y, radius * 2, radius * 2, 180, 90);
            gp.CloseFigure();
            g.DrawPath(p, gp);
            g.FillPath(brushFill, gp);
            gp.Dispose();
        }
    }



}
