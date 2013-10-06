namespace HDSurvey
{
	partial class SurveyForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.txt_BasePath = new System.Windows.Forms.TextBox();
            this.btn_Go = new System.Windows.Forms.Button();
            this.btn_Stop = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btn_Save = new System.Windows.Forms.Button();
            this.grp_Status = new System.Windows.Forms.GroupBox();
            this.btn_Expand = new System.Windows.Forms.Button();
            this.lbl_CompressionTimeValue = new System.Windows.Forms.Label();
            this.lbl_CollectionTimeValue = new System.Windows.Forms.Label();
            this.lbl_CollectionTime = new System.Windows.Forms.Label();
            this.lbl_CompressionTime = new System.Windows.Forms.Label();
            this.lbl_OverallStatus = new System.Windows.Forms.Label();
            this.lbl_TestResultSizeValue = new System.Windows.Forms.Label();
            this.lbl_TestedSizeValue = new System.Windows.Forms.Label();
            this.lbl_TotalFileSizeValue = new System.Windows.Forms.Label();
            this.lbl_ExtensionsTestedValue = new System.Windows.Forms.Label();
            this.lbl_ExtensionsFoundValue = new System.Windows.Forms.Label();
            this.lbl_FilesTestedValue = new System.Windows.Forms.Label();
            this.lbl_TotalFilesFoundValue = new System.Windows.Forms.Label();
            this.lbl_TestResultSize = new System.Windows.Forms.Label();
            this.lbl_TestedSize = new System.Windows.Forms.Label();
            this.lbl_TotalFileSize = new System.Windows.Forms.Label();
            this.lbl_ExtensionsTested = new System.Windows.Forms.Label();
            this.lbl_FilesTested = new System.Windows.Forms.Label();
            this.lbl_ExtensionsFound = new System.Windows.Forms.Label();
            this.lbl_FoundFileCount = new System.Windows.Forms.Label();
            this.dgv_Extensions = new System.Windows.Forms.DataGridView();
            this.chk_IncludeFileDetails = new System.Windows.Forms.CheckBox();
            this.btn_Browse = new System.Windows.Forms.Button();
            this.txt_MaxTestBytes = new System.Windows.Forms.TextBox();
            this.lbl_MaxTestBytes = new System.Windows.Forms.Label();
            this.txt_MinFileCount = new System.Windows.Forms.TextBox();
            this.lbl_MinFileCount = new System.Windows.Forms.Label();
            this.lbl_SearchPath = new System.Windows.Forms.Label();
            this.btn_Export = new System.Windows.Forms.Button();
            this.btn_Collapse = new System.Windows.Forms.Button();
            this.dgv_Files = new System.Windows.Forms.DataGridView();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.chk_TestKnownTypes = new System.Windows.Forms.CheckBox();
            this.grp_CompressionTest = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.grp_Status.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Extensions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Files)).BeginInit();
            this.grp_CompressionTest.SuspendLayout();
            this.SuspendLayout();
            // 
            // txt_BasePath
            // 
            this.txt_BasePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_BasePath.Location = new System.Drawing.Point(95, 7);
            this.txt_BasePath.Name = "txt_BasePath";
            this.txt_BasePath.Size = new System.Drawing.Size(703, 22);
            this.txt_BasePath.TabIndex = 0;
            this.txt_BasePath.Text = "C:\\";
            // 
            // btn_Go
            // 
            this.btn_Go.Location = new System.Drawing.Point(6, 75);
            this.btn_Go.Name = "btn_Go";
            this.btn_Go.Size = new System.Drawing.Size(75, 23);
            this.btn_Go.TabIndex = 1;
            this.btn_Go.Text = "Go";
            this.btn_Go.UseVisualStyleBackColor = true;
            this.btn_Go.Click += new System.EventHandler(this.btn_Go_Click);
            // 
            // btn_Stop
            // 
            this.btn_Stop.Enabled = false;
            this.btn_Stop.Location = new System.Drawing.Point(6, 104);
            this.btn_Stop.Name = "btn_Stop";
            this.btn_Stop.Size = new System.Drawing.Size(75, 23);
            this.btn_Stop.TabIndex = 2;
            this.btn_Stop.Text = "Abort";
            this.btn_Stop.UseVisualStyleBackColor = true;
            this.btn_Stop.Click += new System.EventHandler(this.btn_Stop_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(12, 5);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.grp_CompressionTest);
            this.splitContainer1.Panel1.Controls.Add(this.btn_Save);
            this.splitContainer1.Panel1.Controls.Add(this.grp_Status);
            this.splitContainer1.Panel1.Controls.Add(this.chk_IncludeFileDetails);
            this.splitContainer1.Panel1.Controls.Add(this.btn_Browse);
            this.splitContainer1.Panel1.Controls.Add(this.lbl_SearchPath);
            this.splitContainer1.Panel1.Controls.Add(this.btn_Export);
            this.splitContainer1.Panel1.Controls.Add(this.txt_BasePath);
            this.splitContainer1.Panel1.Controls.Add(this.btn_Stop);
            this.splitContainer1.Panel1.Controls.Add(this.btn_Go);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btn_Collapse);
            this.splitContainer1.Panel2.Controls.Add(this.dgv_Files);
            this.splitContainer1.Size = new System.Drawing.Size(1305, 389);
            this.splitContainer1.SplitterDistance = 882;
            this.splitContainer1.TabIndex = 4;
            // 
            // btn_Save
            // 
            this.btn_Save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Save.Location = new System.Drawing.Point(689, 75);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(184, 23);
            this.btn_Save.TabIndex = 13;
            this.btn_Save.Text = "Save Compressed List";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // grp_Status
            // 
            this.grp_Status.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grp_Status.Controls.Add(this.btn_Expand);
            this.grp_Status.Controls.Add(this.lbl_CompressionTimeValue);
            this.grp_Status.Controls.Add(this.lbl_CollectionTimeValue);
            this.grp_Status.Controls.Add(this.lbl_CollectionTime);
            this.grp_Status.Controls.Add(this.lbl_CompressionTime);
            this.grp_Status.Controls.Add(this.lbl_OverallStatus);
            this.grp_Status.Controls.Add(this.lbl_TestResultSizeValue);
            this.grp_Status.Controls.Add(this.lbl_TestedSizeValue);
            this.grp_Status.Controls.Add(this.lbl_TotalFileSizeValue);
            this.grp_Status.Controls.Add(this.lbl_ExtensionsTestedValue);
            this.grp_Status.Controls.Add(this.lbl_ExtensionsFoundValue);
            this.grp_Status.Controls.Add(this.lbl_FilesTestedValue);
            this.grp_Status.Controls.Add(this.lbl_TotalFilesFoundValue);
            this.grp_Status.Controls.Add(this.lbl_TestResultSize);
            this.grp_Status.Controls.Add(this.lbl_TestedSize);
            this.grp_Status.Controls.Add(this.lbl_TotalFileSize);
            this.grp_Status.Controls.Add(this.lbl_ExtensionsTested);
            this.grp_Status.Controls.Add(this.lbl_FilesTested);
            this.grp_Status.Controls.Add(this.lbl_ExtensionsFound);
            this.grp_Status.Controls.Add(this.lbl_FoundFileCount);
            this.grp_Status.Controls.Add(this.dgv_Extensions);
            this.grp_Status.Location = new System.Drawing.Point(6, 133);
            this.grp_Status.Name = "grp_Status";
            this.grp_Status.Size = new System.Drawing.Size(873, 253);
            this.grp_Status.TabIndex = 12;
            this.grp_Status.TabStop = false;
            this.grp_Status.Text = "Progress / Status";
            // 
            // btn_Expand
            // 
            this.btn_Expand.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Expand.Location = new System.Drawing.Point(844, 63);
            this.btn_Expand.Name = "btn_Expand";
            this.btn_Expand.Size = new System.Drawing.Size(23, 23);
            this.btn_Expand.TabIndex = 15;
            this.btn_Expand.Text = ">";
            this.btn_Expand.UseVisualStyleBackColor = true;
            this.btn_Expand.Click += new System.EventHandler(this.btn_Expand_Click);
            // 
            // lbl_CompressionTimeValue
            // 
            this.lbl_CompressionTimeValue.AutoSize = true;
            this.lbl_CompressionTimeValue.Location = new System.Drawing.Point(144, 69);
            this.lbl_CompressionTimeValue.Name = "lbl_CompressionTimeValue";
            this.lbl_CompressionTimeValue.Size = new System.Drawing.Size(20, 17);
            this.lbl_CompressionTimeValue.TabIndex = 14;
            this.lbl_CompressionTimeValue.Text = "...";
            // 
            // lbl_CollectionTimeValue
            // 
            this.lbl_CollectionTimeValue.AutoSize = true;
            this.lbl_CollectionTimeValue.Location = new System.Drawing.Point(144, 52);
            this.lbl_CollectionTimeValue.Name = "lbl_CollectionTimeValue";
            this.lbl_CollectionTimeValue.Size = new System.Drawing.Size(20, 17);
            this.lbl_CollectionTimeValue.TabIndex = 14;
            this.lbl_CollectionTimeValue.Text = "...";
            // 
            // lbl_CollectionTime
            // 
            this.lbl_CollectionTime.AutoSize = true;
            this.lbl_CollectionTime.Location = new System.Drawing.Point(6, 52);
            this.lbl_CollectionTime.Name = "lbl_CollectionTime";
            this.lbl_CollectionTime.Size = new System.Drawing.Size(108, 17);
            this.lbl_CollectionTime.TabIndex = 14;
            this.lbl_CollectionTime.Text = "Collection Time:";
            // 
            // lbl_CompressionTime
            // 
            this.lbl_CompressionTime.AutoSize = true;
            this.lbl_CompressionTime.Location = new System.Drawing.Point(6, 69);
            this.lbl_CompressionTime.Name = "lbl_CompressionTime";
            this.lbl_CompressionTime.Size = new System.Drawing.Size(129, 17);
            this.lbl_CompressionTime.TabIndex = 14;
            this.lbl_CompressionTime.Text = "Compression Time:";
            // 
            // lbl_OverallStatus
            // 
            this.lbl_OverallStatus.AutoSize = true;
            this.lbl_OverallStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_OverallStatus.Location = new System.Drawing.Point(6, 18);
            this.lbl_OverallStatus.Name = "lbl_OverallStatus";
            this.lbl_OverallStatus.Size = new System.Drawing.Size(105, 20);
            this.lbl_OverallStatus.TabIndex = 13;
            this.lbl_OverallStatus.Text = "Not Started";
            // 
            // lbl_TestResultSizeValue
            // 
            this.lbl_TestResultSizeValue.AutoSize = true;
            this.lbl_TestResultSizeValue.Location = new System.Drawing.Point(632, 69);
            this.lbl_TestResultSizeValue.Name = "lbl_TestResultSizeValue";
            this.lbl_TestResultSizeValue.Size = new System.Drawing.Size(16, 17);
            this.lbl_TestResultSizeValue.TabIndex = 12;
            this.lbl_TestResultSizeValue.Text = "0";
            // 
            // lbl_TestedSizeValue
            // 
            this.lbl_TestedSizeValue.AutoSize = true;
            this.lbl_TestedSizeValue.Location = new System.Drawing.Point(632, 52);
            this.lbl_TestedSizeValue.Name = "lbl_TestedSizeValue";
            this.lbl_TestedSizeValue.Size = new System.Drawing.Size(16, 17);
            this.lbl_TestedSizeValue.TabIndex = 12;
            this.lbl_TestedSizeValue.Text = "0";
            // 
            // lbl_TotalFileSizeValue
            // 
            this.lbl_TotalFileSizeValue.AutoSize = true;
            this.lbl_TotalFileSizeValue.Location = new System.Drawing.Point(433, 52);
            this.lbl_TotalFileSizeValue.Name = "lbl_TotalFileSizeValue";
            this.lbl_TotalFileSizeValue.Size = new System.Drawing.Size(16, 17);
            this.lbl_TotalFileSizeValue.TabIndex = 12;
            this.lbl_TotalFileSizeValue.Text = "0";
            // 
            // lbl_ExtensionsTestedValue
            // 
            this.lbl_ExtensionsTestedValue.AutoSize = true;
            this.lbl_ExtensionsTestedValue.Location = new System.Drawing.Point(632, 18);
            this.lbl_ExtensionsTestedValue.Name = "lbl_ExtensionsTestedValue";
            this.lbl_ExtensionsTestedValue.Size = new System.Drawing.Size(16, 17);
            this.lbl_ExtensionsTestedValue.TabIndex = 12;
            this.lbl_ExtensionsTestedValue.Text = "0";
            // 
            // lbl_ExtensionsFoundValue
            // 
            this.lbl_ExtensionsFoundValue.AutoSize = true;
            this.lbl_ExtensionsFoundValue.Location = new System.Drawing.Point(433, 18);
            this.lbl_ExtensionsFoundValue.Name = "lbl_ExtensionsFoundValue";
            this.lbl_ExtensionsFoundValue.Size = new System.Drawing.Size(16, 17);
            this.lbl_ExtensionsFoundValue.TabIndex = 12;
            this.lbl_ExtensionsFoundValue.Text = "0";
            // 
            // lbl_FilesTestedValue
            // 
            this.lbl_FilesTestedValue.AutoSize = true;
            this.lbl_FilesTestedValue.Location = new System.Drawing.Point(632, 35);
            this.lbl_FilesTestedValue.Name = "lbl_FilesTestedValue";
            this.lbl_FilesTestedValue.Size = new System.Drawing.Size(16, 17);
            this.lbl_FilesTestedValue.TabIndex = 12;
            this.lbl_FilesTestedValue.Text = "0";
            // 
            // lbl_TotalFilesFoundValue
            // 
            this.lbl_TotalFilesFoundValue.AutoSize = true;
            this.lbl_TotalFilesFoundValue.Location = new System.Drawing.Point(433, 35);
            this.lbl_TotalFilesFoundValue.Name = "lbl_TotalFilesFoundValue";
            this.lbl_TotalFilesFoundValue.Size = new System.Drawing.Size(16, 17);
            this.lbl_TotalFilesFoundValue.TabIndex = 12;
            this.lbl_TotalFilesFoundValue.Text = "0";
            // 
            // lbl_TestResultSize
            // 
            this.lbl_TestResultSize.AutoSize = true;
            this.lbl_TestResultSize.Location = new System.Drawing.Point(504, 69);
            this.lbl_TestResultSize.Name = "lbl_TestResultSize";
            this.lbl_TestResultSize.Size = new System.Drawing.Size(115, 17);
            this.lbl_TestResultSize.TabIndex = 11;
            this.lbl_TestResultSize.Text = "Test Result Size:";
            // 
            // lbl_TestedSize
            // 
            this.lbl_TestedSize.AutoSize = true;
            this.lbl_TestedSize.Location = new System.Drawing.Point(504, 52);
            this.lbl_TestedSize.Name = "lbl_TestedSize";
            this.lbl_TestedSize.Size = new System.Drawing.Size(87, 17);
            this.lbl_TestedSize.TabIndex = 11;
            this.lbl_TestedSize.Text = "Tested Size:";
            // 
            // lbl_TotalFileSize
            // 
            this.lbl_TotalFileSize.AutoSize = true;
            this.lbl_TotalFileSize.Location = new System.Drawing.Point(305, 52);
            this.lbl_TotalFileSize.Name = "lbl_TotalFileSize";
            this.lbl_TotalFileSize.Size = new System.Drawing.Size(101, 17);
            this.lbl_TotalFileSize.TabIndex = 11;
            this.lbl_TotalFileSize.Text = "Total File Size:";
            // 
            // lbl_ExtensionsTested
            // 
            this.lbl_ExtensionsTested.AutoSize = true;
            this.lbl_ExtensionsTested.Location = new System.Drawing.Point(504, 18);
            this.lbl_ExtensionsTested.Name = "lbl_ExtensionsTested";
            this.lbl_ExtensionsTested.Size = new System.Drawing.Size(128, 17);
            this.lbl_ExtensionsTested.TabIndex = 11;
            this.lbl_ExtensionsTested.Text = "Extensions Tested:";
            // 
            // lbl_FilesTested
            // 
            this.lbl_FilesTested.AutoSize = true;
            this.lbl_FilesTested.Location = new System.Drawing.Point(504, 35);
            this.lbl_FilesTested.Name = "lbl_FilesTested";
            this.lbl_FilesTested.Size = new System.Drawing.Size(89, 17);
            this.lbl_FilesTested.TabIndex = 11;
            this.lbl_FilesTested.Text = "Files Tested:";
            // 
            // lbl_ExtensionsFound
            // 
            this.lbl_ExtensionsFound.AutoSize = true;
            this.lbl_ExtensionsFound.Location = new System.Drawing.Point(305, 18);
            this.lbl_ExtensionsFound.Name = "lbl_ExtensionsFound";
            this.lbl_ExtensionsFound.Size = new System.Drawing.Size(124, 17);
            this.lbl_ExtensionsFound.TabIndex = 11;
            this.lbl_ExtensionsFound.Text = "Extensions Found:";
            // 
            // lbl_FoundFileCount
            // 
            this.lbl_FoundFileCount.AutoSize = true;
            this.lbl_FoundFileCount.Location = new System.Drawing.Point(305, 35);
            this.lbl_FoundFileCount.Name = "lbl_FoundFileCount";
            this.lbl_FoundFileCount.Size = new System.Drawing.Size(121, 17);
            this.lbl_FoundFileCount.TabIndex = 11;
            this.lbl_FoundFileCount.Text = "Total Files Found:";
            // 
            // dgv_Extensions
            // 
            this.dgv_Extensions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_Extensions.Location = new System.Drawing.Point(6, 90);
            this.dgv_Extensions.Name = "dgv_Extensions";
            this.dgv_Extensions.RowTemplate.Height = 24;
            this.dgv_Extensions.Size = new System.Drawing.Size(861, 157);
            this.dgv_Extensions.TabIndex = 10;
            this.dgv_Extensions.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Extensions_CellDoubleClick);
            this.dgv_Extensions.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Extensions_RowEnter);
            // 
            // chk_IncludeFileDetails
            // 
            this.chk_IncludeFileDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chk_IncludeFileDetails.AutoSize = true;
            this.chk_IncludeFileDetails.Location = new System.Drawing.Point(725, 106);
            this.chk_IncludeFileDetails.Name = "chk_IncludeFileDetails";
            this.chk_IncludeFileDetails.Size = new System.Drawing.Size(148, 21);
            this.chk_IncludeFileDetails.TabIndex = 9;
            this.chk_IncludeFileDetails.Text = "Include File Details";
            this.chk_IncludeFileDetails.UseVisualStyleBackColor = true;
            // 
            // btn_Browse
            // 
            this.btn_Browse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Browse.Location = new System.Drawing.Point(804, 7);
            this.btn_Browse.Name = "btn_Browse";
            this.btn_Browse.Size = new System.Drawing.Size(75, 23);
            this.btn_Browse.TabIndex = 5;
            this.btn_Browse.Text = "Browse";
            this.btn_Browse.UseVisualStyleBackColor = true;
            this.btn_Browse.Click += new System.EventHandler(this.btn_Browse_Click);
            // 
            // txt_MaxTestBytes
            // 
            this.txt_MaxTestBytes.Location = new System.Drawing.Point(176, 43);
            this.txt_MaxTestBytes.Name = "txt_MaxTestBytes";
            this.txt_MaxTestBytes.Size = new System.Drawing.Size(100, 22);
            this.txt_MaxTestBytes.TabIndex = 8;
            this.txt_MaxTestBytes.Text = "1048576";
            // 
            // lbl_MaxTestBytes
            // 
            this.lbl_MaxTestBytes.AutoSize = true;
            this.lbl_MaxTestBytes.Location = new System.Drawing.Point(6, 46);
            this.lbl_MaxTestBytes.Name = "lbl_MaxTestBytes";
            this.lbl_MaxTestBytes.Size = new System.Drawing.Size(138, 17);
            this.lbl_MaxTestBytes.TabIndex = 7;
            this.lbl_MaxTestBytes.Text = "Max Test Bytes / File";
            // 
            // txt_MinFileCount
            // 
            this.txt_MinFileCount.Location = new System.Drawing.Point(176, 18);
            this.txt_MinFileCount.Name = "txt_MinFileCount";
            this.txt_MinFileCount.Size = new System.Drawing.Size(100, 22);
            this.txt_MinFileCount.TabIndex = 6;
            this.txt_MinFileCount.Text = "100";
            // 
            // lbl_MinFileCount
            // 
            this.lbl_MinFileCount.AutoSize = true;
            this.lbl_MinFileCount.Location = new System.Drawing.Point(6, 21);
            this.lbl_MinFileCount.Name = "lbl_MinFileCount";
            this.lbl_MinFileCount.Size = new System.Drawing.Size(164, 17);
            this.lbl_MinFileCount.TabIndex = 5;
            this.lbl_MinFileCount.Text = "Min Filecount / Extension";
            // 
            // lbl_SearchPath
            // 
            this.lbl_SearchPath.AutoSize = true;
            this.lbl_SearchPath.Location = new System.Drawing.Point(3, 10);
            this.lbl_SearchPath.Name = "lbl_SearchPath";
            this.lbl_SearchPath.Size = new System.Drawing.Size(86, 17);
            this.lbl_SearchPath.TabIndex = 4;
            this.lbl_SearchPath.Text = "Search Path";
            // 
            // btn_Export
            // 
            this.btn_Export.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Export.Enabled = false;
            this.btn_Export.Location = new System.Drawing.Point(641, 104);
            this.btn_Export.Name = "btn_Export";
            this.btn_Export.Size = new System.Drawing.Size(75, 23);
            this.btn_Export.TabIndex = 3;
            this.btn_Export.Text = "Export";
            this.btn_Export.UseVisualStyleBackColor = true;
            this.btn_Export.Click += new System.EventHandler(this.btn_Export_Click);
            // 
            // btn_Collapse
            // 
            this.btn_Collapse.Location = new System.Drawing.Point(3, 196);
            this.btn_Collapse.Name = "btn_Collapse";
            this.btn_Collapse.Size = new System.Drawing.Size(23, 23);
            this.btn_Collapse.TabIndex = 15;
            this.btn_Collapse.Text = "<";
            this.btn_Collapse.UseVisualStyleBackColor = true;
            this.btn_Collapse.Click += new System.EventHandler(this.btn_Collapse_Click);
            // 
            // dgv_Files
            // 
            this.dgv_Files.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_Files.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Files.Location = new System.Drawing.Point(32, 3);
            this.dgv_Files.Name = "dgv_Files";
            this.dgv_Files.RowTemplate.Height = 24;
            this.dgv_Files.Size = new System.Drawing.Size(384, 383);
            this.dgv_Files.TabIndex = 3;
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "*.xlsx";
            // 
            // chk_TestKnownTypes
            // 
            this.chk_TestKnownTypes.AutoSize = true;
            this.chk_TestKnownTypes.Location = new System.Drawing.Point(9, 69);
            this.chk_TestKnownTypes.Name = "chk_TestKnownTypes";
            this.chk_TestKnownTypes.Size = new System.Drawing.Size(190, 21);
            this.chk_TestKnownTypes.TabIndex = 14;
            this.chk_TestKnownTypes.Text = "Include known extensions";
            this.chk_TestKnownTypes.UseVisualStyleBackColor = true;
            // 
            // grp_CompressionTest
            // 
            this.grp_CompressionTest.Controls.Add(this.lbl_MinFileCount);
            this.grp_CompressionTest.Controls.Add(this.chk_TestKnownTypes);
            this.grp_CompressionTest.Controls.Add(this.txt_MinFileCount);
            this.grp_CompressionTest.Controls.Add(this.lbl_MaxTestBytes);
            this.grp_CompressionTest.Controls.Add(this.txt_MaxTestBytes);
            this.grp_CompressionTest.Location = new System.Drawing.Point(115, 35);
            this.grp_CompressionTest.Name = "grp_CompressionTest";
            this.grp_CompressionTest.Size = new System.Drawing.Size(340, 100);
            this.grp_CompressionTest.TabIndex = 15;
            this.grp_CompressionTest.TabStop = false;
            this.grp_CompressionTest.Text = "Compression Test";
            // 
            // SurveyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1329, 406);
            this.Controls.Add(this.splitContainer1);
            this.Name = "SurveyForm";
            this.Text = "File Extension and Compression Survey";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SurveyForm_FormClosed);
            this.Load += new System.EventHandler(this.SurveyForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.grp_Status.ResumeLayout(false);
            this.grp_Status.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Extensions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Files)).EndInit();
            this.grp_CompressionTest.ResumeLayout(false);
            this.grp_CompressionTest.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

        private System.Windows.Forms.TextBox txt_BasePath;
        private System.Windows.Forms.Button btn_Go;
        private System.Windows.Forms.Button btn_Stop;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btn_Export;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.TextBox txt_MaxTestBytes;
        private System.Windows.Forms.Label lbl_MaxTestBytes;
        private System.Windows.Forms.TextBox txt_MinFileCount;
        private System.Windows.Forms.Label lbl_MinFileCount;
        private System.Windows.Forms.Label lbl_SearchPath;
        private System.Windows.Forms.Button btn_Browse;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.CheckBox chk_IncludeFileDetails;
        private System.Windows.Forms.Label lbl_FoundFileCount;
        private System.Windows.Forms.DataGridView dgv_Extensions;
        private System.Windows.Forms.GroupBox grp_Status;
        private System.Windows.Forms.Label lbl_TotalFileSize;
        private System.Windows.Forms.Label lbl_TotalFileSizeValue;
        private System.Windows.Forms.Label lbl_TotalFilesFoundValue;
        private System.Windows.Forms.Label lbl_ExtensionsFoundValue;
        private System.Windows.Forms.Label lbl_ExtensionsFound;
        private System.Windows.Forms.Label lbl_TestedSizeValue;
        private System.Windows.Forms.Label lbl_ExtensionsTestedValue;
        private System.Windows.Forms.Label lbl_FilesTestedValue;
        private System.Windows.Forms.Label lbl_TestedSize;
        private System.Windows.Forms.Label lbl_ExtensionsTested;
        private System.Windows.Forms.Label lbl_FilesTested;
        private System.Windows.Forms.Label lbl_TestResultSizeValue;
        private System.Windows.Forms.Label lbl_TestResultSize;
        private System.Windows.Forms.Label lbl_OverallStatus;
        private System.Windows.Forms.Label lbl_CompressionTime;
        private System.Windows.Forms.Label lbl_CompressionTimeValue;
        private System.Windows.Forms.Label lbl_CollectionTimeValue;
        private System.Windows.Forms.Label lbl_CollectionTime;
        private System.Windows.Forms.DataGridView dgv_Files;
        private System.Windows.Forms.Button btn_Expand;
        private System.Windows.Forms.Button btn_Collapse;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.GroupBox grp_CompressionTest;
        private System.Windows.Forms.CheckBox chk_TestKnownTypes;
	}
}

