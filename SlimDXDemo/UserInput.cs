using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SlimDX.DirectInput;
using SlimDX.XInput;
namespace SlimDXDemo
{
    class UserInput : IDisposable
    {
        bool m_IsDisposed = false;
        DirectInput m_DirectInput;

        Keyboard m_Keyboard;
        KeyboardState m_KeyboardStateCurrent;
        KeyboardState m_KeyboardStateLast;

        Mouse m_Mouse;
        MouseState m_MouseStateCurrent;
        MouseState m_MouseStateLast;

        public UserInput()
        {
            InitDirectInput();

            m_KeyboardStateCurrent = new KeyboardState();
            m_KeyboardStateLast = new KeyboardState();

            m_MouseStateCurrent = new MouseState();
            m_MouseStateLast = new MouseState();
        }

        private void InitDirectInput()
        {
            m_DirectInput = new DirectInput();
            m_Keyboard = new Keyboard(m_DirectInput);
            m_Mouse = new Mouse(m_DirectInput);
        }
        public void Update()
        {
            m_Keyboard.Acquire();
            m_Mouse.Acquire();

            m_KeyboardStateLast = m_KeyboardStateCurrent;
            m_KeyboardStateCurrent = m_Keyboard.GetCurrentState();

            m_MouseStateLast = m_MouseStateCurrent;
            m_MouseStateCurrent = m_Mouse.GetCurrentState();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.m_IsDisposed)
            {
                if (disposing)
                {
                    if (m_DirectInput != null)
                    {
                        m_DirectInput.Dispose();
                    }
                    if (m_Keyboard != null)
                    {
                        m_Keyboard.Dispose();
                    }
                    if (m_Mouse != null)
                    {
                        m_Mouse.Dispose();
                    }
                }
            }
            m_IsDisposed = true;
        }
        public bool IsDisposed
        {
            get
            {
                return m_IsDisposed;
            }
        }
        public Keyboard Keyboard
        {
            get
            {
                return m_Keyboard;
            }
        }
        public KeyboardState KeyboardStateCurrent
        {
            get
            {
                return m_KeyboardStateCurrent;
            }
        }
        public KeyboardState KeyboardStateLast
        {
            get
            {
                return m_KeyboardStateLast;
            }
        }
        public Mouse Mouse
        {
            get
            {
                return m_Mouse;
            }
        }
        public MouseState MouseStateCurrent
        {
            get
            {
                return m_MouseStateCurrent;
            }
        }
        public MouseState MouseStateLast
        {
            get
            {
                return m_MouseStateLast;
            }
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
