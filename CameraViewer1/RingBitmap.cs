using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using AVT.VmbAPINET;

namespace CameraViewer1
{
    internal class RingBitmap
    {
        /// <summary>
        /// The bitmap size
        /// </summary>
        private int m_Size = 0;

        /// <summary>
        /// Bitmaps to display images
        /// </summary>
        private Bitmap[] m_Bitmaps = null;

        /// <summary>
        /// selects Bitmap
        /// </summary>
        private int m_BitmapSelector = 0;

        /// <summary>
        /// Initializes a new instance of the RingBitmap class.
        /// </summary>
        /// <param name="size">The bitmap size</param>
        public RingBitmap(int size)
        {
            m_Size = size;
            m_Bitmaps = new Bitmap[m_Size];
        }

        /// <summary>
        /// Gets the current bitmap as image
        /// </summary>
        public Image Image
        {
            get
            {
                return m_Bitmaps[m_BitmapSelector];
            }
        }

        /// <summary>
        /// Fill Frame in 8bppIndexed bitmap
        /// </summary>
        /// <param name="frame">The Vimba frame</param>
        public void FillNextBitmap(Frame frame)
        {
            // switch to Bitmap object which is currently not in use by GUI
            SwitchBitmap();

            frame.Fill(ref m_Bitmaps[m_BitmapSelector]);
        }

        /// <summary>
        /// Bitmap rotation selector
        /// </summary>
        private void SwitchBitmap()
        {
            m_BitmapSelector++;

            if (m_Size == m_BitmapSelector)
            {
                m_BitmapSelector = 0;
            }
        }
    }
}