using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArduinoGraphViewer
{
    public partial class GetAssetsForm : Form, IDisposable
    {
        #region VARS

        private List<Asset> assets = new List<Asset>();
        private int currentAssetID = 0;

        #endregion

        #region CONSTRUCTOR

        public GetAssetsForm()
        {
            InitializeComponent();
            Init();
        }

        #endregion

        #region BUTTONS

        private void BtnPrev_Click(object sender, EventArgs e)
        {
            try
            {
                currentAssetID--;
                if (currentAssetID < 0) currentAssetID = 0;
                RefreshUI();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void BtnNext_Click(object sender, EventArgs e)
        {
            try
            {
                currentAssetID++;
                if (currentAssetID >= assets.Count) currentAssetID = assets.Count - 1;
                RefreshUI();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void BtnGetFile_Click(object sender, EventArgs e)
        {
            try
            {
                if (assets[currentAssetID].File == null)
                {
                    MessageBox.Show("No file data available for this asset.");
                    return;
                }

                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                    sfd.FileName = assets[currentAssetID].FileName;
                    sfd.Filter = $"*.{assets[currentAssetID].FileExtension}|*.{assets[currentAssetID].FileExtension}|All files (*.*)|*.*";
                    sfd.FilterIndex = 1;
                    sfd.RestoreDirectory = true;
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {

                        using (var stream = new MemoryStream(assets[currentAssetID].File!))
                        {
                            stream.Position = 0;
                            using (var fileStream = new FileStream(sfd.FileName, FileMode.Create, FileAccess.Write))
                            {
                                stream.CopyTo(fileStream);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
            }
        }

        #endregion

        #region FUNCTIONS

        private void Init()
        {
            try
            {
                LoadAllAssets();
                RefreshUI();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void RefreshUI()
        {
            try
            {
                if (pbSchematic.Image != null)
                    pbSchematic.Image.Dispose();

                if (assets[currentAssetID].Picture != null)
                {
                    pbSchematic.Image = (Image)assets[currentAssetID].Picture.Clone();
                    pbSchematic.Invalidate();
                }

                LblCurrentAssetAndTotal.Text = $"Asset {currentAssetID + 1} of {assets.Count}";
                if(assets[currentAssetID].FileName != null)
                    LblFileName.Text = $"Asset: {assets[currentAssetID].FileName}.{assets[currentAssetID].FileExtension}";

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void LoadAllAssets()
        {
            try
            {
                int assetCounter = 0;
                var assembly = Assembly.GetExecutingAssembly();
                var resourceNames = assembly.GetManifestResourceNames();

                // Group by folder name (e.g., Asset1, Asset2)
                var grouped = resourceNames
                    .Where(n => n.StartsWith("ArduinoGraphViewer.Assets.Asset"))
                    .GroupBy(n =>
                    {
                        // Extract folder name between "Assets." and filename
                        var parts = n.Split('.');
                        var assetFolder = parts.Length >= 4 ? parts[2] : "Unknown";
                        return assetFolder;
                    });

                foreach (var group in grouped)
                {
                    var asset = new Asset { AssetID = assetCounter++ };

                    foreach (var res in group)
                    {
                        using Stream? stream = assembly.GetManifestResourceStream(res);
                        if (stream != null)
                        {
                            if (res.EndsWith(".png") || res.EndsWith(".jpg"))
                            {
                                asset.Picture = Image.FromStream(stream);
                            }
                            else
                            {
                                using var ms = new MemoryStream();
                                stream.CopyTo(ms);
                                asset.File = ms.ToArray();
                                asset.FileName = Path.GetFileNameWithoutExtension(res).Split('.').Last();
                                asset.FileExtension = Path.GetExtension(res).TrimStart('.');
                            }
                        }
                    }

                    // Only add if at least one resource was found
                    if (asset.Picture != null || asset.File != null)
                        assets.Add(asset);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        #endregion

        #region OVERRIDES/NEW

        public new void Dispose()
        {
            try
            {
                if (pbSchematic.Image != null)
                    pbSchematic.Image.Dispose();
                foreach (var asset in assets)
                {
                    if (asset.Picture != null)
                        asset.Picture.Dispose();

                    asset.File = null;
                }
                base.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error during disposal: " + ex.Message);
            }
        }

        #endregion



    }
}
