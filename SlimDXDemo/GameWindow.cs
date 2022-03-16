using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SlimDX;
using SlimDX.Windows;
namespace SlimDXDemo
{
    public class GameWindow:IDisposable
    {
        private bool m_IsDisposed = false;
        private bool m_IsInitialized = false;
        private bool m_IsFullScreen = false;
        private bool m_IsPaused = false;
        private RenderForm m_Form;
        private Color4 m_ClearColor;
        private long m_CurrFrameTime;
        private long m_LastFrameTime;
        private int m_FrameCount;
        private int m_FPS;

        public bool IsDisposed
        {
            get { return m_IsDisposed; }
            protected set { m_IsDisposed = value; }
        }
        public bool IsInitialized
        {
            get { return m_IsInitialized; }
            protected set { m_IsInitialized = value; }
        }
        public bool IsFullScreen
        {
            get { return m_IsFullScreen; }
            protected set { m_IsFullScreen = value; }
        }
        public bool IsPaused
        {
            get { return m_IsPaused; }
            protected set { m_IsPaused = value; }
        }
        public Color4 ClearColor
        {
            get { return m_ClearColor; }
            protected set
            {
                m_ClearColor = value;
            }
        }

        public GameWindow(string title,int width,int height,bool fullscreen)
        {
            m_IsFullScreen = fullscreen;
            m_ClearColor = new Color4(1.0f, 0.0f, 0.0f, 0.0f);
            m_Form = new RenderForm(title);
            m_Form.ClientSize = new System.Drawing.Size(width, height);
            m_Form.FormClosed += FormClosed;
        }

        private void FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!m_IsDisposed)
            {
                Dispose();
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.m_IsDisposed)
            {
                if (disposing)
                {
                    m_Form.FormClosed -= this.FormClosed;
                }
            }
            m_IsDisposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        public virtual void GameLoop()
        {
            m_LastFrameTime = m_CurrFrameTime;
            m_CurrFrameTime = Stopwatch.GetTimestamp();

            UpdateScene((double)(m_CurrFrameTime - m_LastFrameTime) / Stopwatch.Frequency);
            RenderScene();

            m_FPS = (int)(Stopwatch.Frequency / ((float)(m_CurrFrameTime - m_LastFrameTime)));

        }
        public virtual void UpdateScene(double frameTime)
        {

        }
        public virtual void RenderScene()
        {
            if((!this.IsInitialized)|| this.IsDisposed)
            {
                return;
            }
        }

        public void StartGameLoop()
        {
            if (m_IsInitialized)
            {
                return;
            }
            m_IsInitialized = true;
            MessagePump.Run(m_Form, GameLoop);
        }
    }
}
